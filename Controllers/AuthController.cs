using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using BandBlend.Models;
using BandBlend.Data;
using Microsoft.EntityFrameworkCore;

namespace BandBlend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private BandBlendDbContext _dbContext;
    private UserManager<IdentityUser> _userManager;

    public AuthController(BandBlendDbContext context, UserManager<IdentityUser> userManager)
    {
        _dbContext = context;
        _userManager = userManager;
    }

    [HttpPost("login")]
    public IActionResult Login([FromHeader(Name = "Authorization")] string authHeader)
    {
        try
        {
            string encodedCreds = authHeader.Substring(6).Trim();
            string creds = Encoding
            .GetEncoding("iso-8859-1")
            .GetString(Convert.FromBase64String(encodedCreds));

            // Get email and password
            int separator = creds.IndexOf(':');
            string email = creds.Substring(0, separator);
            string password = creds.Substring(separator + 1);

            var user = _dbContext.Users.Where(u => u.Email == email).FirstOrDefault();
            var userRoles = _dbContext.UserRoles.Where(ur => ur.UserId == user.Id).ToList();
            var hasher = new PasswordHasher<IdentityUser>();
            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (user != null && result == PasswordVerificationResult.Success)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)

                };

                foreach (var userRole in userRoles)
                {
                    var role = _dbContext.Roles.FirstOrDefault(r => r.Id == userRole.RoleId);
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity)).Wait();

                return Ok();
            }

            return new UnauthorizedResult();
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    [Route("logout")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public IActionResult Logout()
    {
        try
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("Me")]
    [Authorize]
    public IActionResult Me()
    {
        var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var profile = _dbContext.UserProfiles
        .Include(up => up.Profile).SingleOrDefault(up => up.IdentityUserId == identityUserId);
        var roles = User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();
        if (profile != null)
        {
            profile.Email = User.FindFirstValue(ClaimTypes.Email);
            profile.Roles = roles;
            return Ok(profile);
        }
        return NotFound();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(Registration registration)
    {

        if (_dbContext.Users.Any(u => u.Email == registration.Email))
        {
            return BadRequest("This email is already in use.");
        }

        var user = new IdentityUser
        {
            UserName = registration.Email,
            Email = registration.Email
        };

        var password = Encoding
            .GetEncoding("iso-8859-1")
            .GetString(Convert.FromBase64String(registration.Password));

        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            UserProfile newUserProfile = new UserProfile
            {
                Name = registration.Name,
                IdentityUserId = user.Id,
                IsBand = registration.IsBand,
                Email = registration.Email,
                AccountBanned = false
            };

            _dbContext.UserProfiles.Add(newUserProfile);

            _dbContext.SaveChanges();

            Profile newProfile = new Profile
            {
                UserProfileId = newUserProfile.Id,
                ProfilePicture = registration.ProfilePicUrl,
                StateId = registration.StateId,
                City = registration.City,
                PrimaryGenreId = registration.PrimaryGenreId,
                PrimaryInstrumentId = registration.PrimaryInstrumentId,
                SpotifyLink = registration.Spotify,
                FacebookLink = registration.Facebook,
                InstagramLink = registration.Instagram,
                TikTokLink = registration.TikTok,
            };

            _dbContext.Profiles.Add(newProfile);

            _dbContext.SaveChanges();

            List<ProfileSubGenre> newProfileSubGenres = registration.SubGenreIds.Select(sg => new ProfileSubGenre
            {
                ProfileId = newProfile.Id,
                SubGenreId = sg
            }).ToList();

            List<ProfileTag> newProfileTags = registration.TagIds.Select(tag => new ProfileTag
            {
                ProfileId = newProfile.Id,
                TagId = tag
            }).ToList();

            FeedStateSubscription newFeedStateSubscription = new FeedStateSubscription {
                UserProfileId = newUserProfile.Id,
                StateId = registration.StateId
            };
            FeedPrimaryGenreSubscription newFeedPrimaryGenreSubscription = new FeedPrimaryGenreSubscription {
                UserProfileId = newUserProfile.Id,
                PrimaryGenreId = registration.PrimaryGenreId
            };

            _dbContext.FeedStateSubscriptions.Add(newFeedStateSubscription);
            _dbContext.FeedPrimaryGenreSubscriptions.Add(newFeedPrimaryGenreSubscription);
            _dbContext.ProfileSubGenres.AddRange(newProfileSubGenres);
            _dbContext.ProfileTags.AddRange(newProfileTags);

            _dbContext.SaveChanges();


            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)

                };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity)).Wait();

            return Ok();
        }
        return StatusCode(500);
    }
}