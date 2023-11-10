using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BandBlend.Data;
using Microsoft.EntityFrameworkCore;
using BandBlend.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace BandBlend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private BandBlendDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;


    public ProfileController(BandBlendDbContext context, UserManager<IdentityUser> userManager)
    {
        _dbContext = context;
        _userManager = userManager;

    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetAllProfiles(int page = 1, int pageSize = 10)
    {

        var loggedInUser = _dbContext
                     .UserProfiles
                     .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        var allProfiles = _dbContext.UserProfiles
            .Include(up => up.Profile)
                .ThenInclude(p => p.PrimaryGenre)
            .Include(up => up.Profile)
                .ThenInclude(p => p.PrimaryInstrument)
            .Include(up => up.Profile)
                .ThenInclude(p => p.State)
            .Include(up => up.Profile)
                .ThenInclude(p => p.ProfileSubGenres)
                .ThenInclude(ps => ps.SubGenre)
            .Include(up => up.Profile)
                .ThenInclude(p => p.ProfileTags)
                .ThenInclude(pt => pt.Tag)
            .Where(up => up.Id != loggedInUser.Id )
            .Skip((page - 1) * pageSize)  // Skip records based on the page number and page size
            .Take(pageSize)  // Take only the records for the current page
            .ToList();

            int count = _dbContext.Profiles.Count();

            var data = new {
                profiles = allProfiles,
                totalCount = count
            };

        return Ok(data);
    }
    // [HttpGet("withroles")]
    // [Authorize(Roles = "Admin")]
    // public IActionResult GetWithRoles()
    // {
    //     return Ok(_dbContext.UserProfiles
    //     .Include(up => up.IdentityUser)
    //     .Select(up => new UserProfile
    //     {
    //         Id = up.Id,
    //         Name = up.Name,
    //         Email = up.IdentityUser.Email,
    //         IdentityUserId = up.IdentityUserId,
    //         Roles = _dbContext.UserRoles
    //         .Where(ur => ur.UserId == up.IdentityUserId)
    //         .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
    //         .ToList()
    //     }));
    // }

    [HttpGet("me")]
    [Authorize]
    public IActionResult GetCurrentUserProfile()
    {
        var loggedInUser = _dbContext
             .UserProfiles
             .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);


        if (loggedInUser != null)
        {
            UserProfile foundUserProfile = _dbContext.UserProfiles
            .Include(up => up.IdentityUser)
            .SingleOrDefault(up => up.Id == loggedInUser.Id);
            
            Profile matchedProfile = _dbContext.Profiles
            .Include(p => p.State)
            .Include(p => p.PrimaryInstrument)
            .Include(p => p.PrimaryGenre)
            .SingleOrDefault(p => p.UserProfileId == foundUserProfile.Id);

            List<ProfileTag> matchedProfileTags = _dbContext.ProfileTags
            .Include(pt => pt.Tag)
            .Where(pt => pt.ProfileId == matchedProfile.Id)
            .ToList();
            
            List<ProfileSubGenre> matchedProfileSubGenres = _dbContext.ProfileSubGenres
            .Include(pt => pt.SubGenre)
            .Where(ps => ps.ProfileId == matchedProfile.Id)
            .ToList();

            matchedProfile.ProfileTags = matchedProfileTags;
            matchedProfile.ProfileSubGenres = matchedProfileSubGenres;

            foundUserProfile.Profile = matchedProfile;

            return Ok(foundUserProfile);
        }
        return NotFound();
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetOtherUserProfile(int id)
    {
        var loggedInUser = _dbContext
             .UserProfiles
             .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);
        if (loggedInUser.Id == id)
        {
            return BadRequest();
        }

        UserProfile foundUserProfile = _dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .SingleOrDefault(up => up.Id == id);

        if (foundUserProfile != null)
        {
            Profile matchedProfile = _dbContext.Profiles
            .Include(p => p.State)
            .Include(p => p.PrimaryInstrument)
            .Include(p => p.PrimaryGenre)
            .SingleOrDefault(p => p.UserProfileId == foundUserProfile.Id);

            List<ProfileTag> matchedProfileTags = _dbContext.ProfileTags
            .Include(pt => pt.Tag)
            .Where(pt => pt.ProfileId == matchedProfile.Id)
            .ToList();

            List<ProfileSubGenre> matchedProfileSubGenres = _dbContext.ProfileSubGenres
            .Include(pt => pt.SubGenre)
            .Where(ps => ps.ProfileId == matchedProfile.Id)
            .ToList();

            matchedProfile.ProfileTags = matchedProfileTags;
            matchedProfile.ProfileSubGenres = matchedProfileSubGenres;

            foundUserProfile.Profile = matchedProfile;

            return Ok(foundUserProfile);
        }
        return NotFound();
    }

    [HttpPost("promote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Promote(string id)
    {
        IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");

        _dbContext.UserRoles.Add(new IdentityUserRole<string>
        {
            RoleId = role.Id,
            UserId = id
        });
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPost("demote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Demote(string id)
    {
        IdentityRole role = _dbContext.Roles
            .SingleOrDefault(r => r.Name == "Admin");
        IdentityUserRole<string> userRole = _dbContext
            .UserRoles
            .SingleOrDefault(ur =>
                ur.RoleId == role.Id &&
                ur.UserId == id);

        _dbContext.UserRoles.Remove(userRole);
        _dbContext.SaveChanges();
        return NoContent();
    }

}