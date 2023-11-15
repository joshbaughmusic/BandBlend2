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

    // [HttpGet]
    // // [Authorize]
    // public IActionResult GetAllProfiles(string search, string filter, string sort, int page = 1, int pageSize = 10)
    // {

    //     var loggedInUser = _dbContext
    //                  .UserProfiles
    //                  .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

    //     var allProfiles = _dbContext.UserProfiles
    //         .Include(up => up.Profile)
    //             .ThenInclude(p => p.PrimaryGenre)
    //         .Include(up => up.Profile)
    //             .ThenInclude(p => p.PrimaryInstrument)
    //         .Include(up => up.Profile)
    //             .ThenInclude(p => p.State)
    //         .Include(up => up.Profile)
    //             .ThenInclude(p => p.ProfileSubGenres)
    //             .ThenInclude(ps => ps.SubGenre)
    //         .Include(up => up.Profile)
    //             .ThenInclude(p => p.ProfileTags)
    //             .ThenInclude(pt => pt.Tag)
    //         .Where(up => up.Id != loggedInUser.Id)
    //         .Skip((page - 1) * pageSize)  // Skip records based on the page number and page size
    //         .Take(pageSize)  // Take only the records for the current page
    //         .ToList();

    //     int count = _dbContext.Profiles.Count();

    //     var data = new
    //     {
    //         profiles = allProfiles,
    //         totalCount = count
    //     };

    //     return Ok(data);
    // }

    [HttpGet]
    public IActionResult GetAllProfiles(string search = null, string filter = null, string sort = null, int page = 1, int pageSize = 10)
    {

        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<SavedProfile> savedProfilesByUser = _dbContext.SavedProfiles.Where(sp => sp.UserProfileId == loggedInUser.Id).ToList();

        var query = _dbContext.UserProfiles
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
            .Where(up => up.Id != loggedInUser.Id);

        foreach (UserProfile up in query)
        {
            if (savedProfilesByUser.Any(sp => sp.ProfileId == up.Profile.Id))
            {
                up.Profile.SavedProfile = savedProfilesByUser.Single(sp => sp.ProfileId == up.Profile.Id);
            }

        }

        // Apply filters based on the provided parameters
        if (search != "undefined" && search != null)
        {
            query = query
            .Where(up => up.Name.ToLower().Contains(search.ToLower()) ||
            up.Profile.PrimaryGenre.Name.ToLower().Contains(search.ToLower()) ||
            up.Profile.PrimaryInstrument.Name.ToLower().Contains(search.ToLower()) ||
            up.Profile.City.ToLower().Contains(search.ToLower()) ||
            up.Profile.State.Name.ToLower().Contains(search.ToLower())
            );
        }

        if (filter != "undefined" && filter != null)
        {
            if (filter == "saved")
            {
                query = query
                .Where(up => up.Profile.SavedProfile != null);
            }
            if (filter == "bands")
            {
                query = query
                .Where(up => up.IsBand == true);
            }
            if (filter == "musicians")
            {
                query = query
                .Where(up => up.IsBand == false);
            }
        }

        if (sort != "undefined" && sort != null)
        {
            if (sort == "naz")
            {
                query = query.OrderBy(up => up.Name);
            }
            if (sort == "nza")
            {
                query = query.OrderByDescending(up => up.Name);
            }
            if (sort == "caz")
            {
                query = query.OrderBy(up => up.Profile.City);
            }
            if (sort == "cza")
            {
                query = query.OrderByDescending(up => up.Profile.City);
            }
            if (sort == "saz")
            {
                query = query.OrderBy(up => up.Profile.State.Name);
            }
            if (sort == "sza")
            {
                query = query.OrderByDescending(up => up.Profile.State.Name);
            }
            if (sort == "piaz")
            {
                query = query.OrderBy(up => up.Profile.PrimaryInstrument.Name);
            }
            if (sort == "piza")
            {
                query = query.OrderByDescending(up => up.Profile.PrimaryInstrument.Name);
            }
            if (sort == "pgaz")
            {
                query = query.OrderBy(up => up.Profile.PrimaryGenre.Name);
            }
            if (sort == "pgza")
            {
                query = query.OrderByDescending(up => up.Profile.PrimaryGenre.Name);
            }

        }

        var allProfiles = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        int count = query.Count();

        var data = new
        {
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

            foundUserProfile.Profile.PostCount = _dbContext.Posts.Where(p => p.UserProfileId == loggedInUser.Id).Count();

            foundUserProfile.Profile.PhotoCount = _dbContext.AdditionalPictures.Where(ap => ap.UserProfileId == loggedInUser.Id).Count();

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

            foundUserProfile.Profile.PostCount = _dbContext.Posts.Where(p => p.UserProfileId == id).Count();

            foundUserProfile.Profile.PhotoCount = _dbContext.AdditionalPictures.Where(ap => ap.UserProfileId == id).Count();

            List<SavedProfile> savedProfilesByUser = _dbContext.SavedProfiles.Where(sp => sp.UserProfileId == loggedInUser.Id).ToList();

            if (savedProfilesByUser.Any(sp => sp.ProfileId == foundUserProfile.Profile.Id))
            {
                foundUserProfile.Profile.SavedProfile = savedProfilesByUser.Single(sp => sp.ProfileId == foundUserProfile.Profile.Id);
            }

            return Ok(foundUserProfile);
        }
        return NotFound();
    }

    [HttpPost("{id}/save")]
    [Authorize]
    public IActionResult SaveProfile(int id)
    {
        Profile foundProfile = _dbContext.Profiles.SingleOrDefault(p => p.Id == id);

        if (foundProfile != null)
        {
            var loggedInUser = _dbContext
                 .UserProfiles
                 .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            SavedProfile newSavedProfile = new SavedProfile
            {
                ProfileId = id,
                UserProfileId = loggedInUser.Id
            };

            _dbContext.SavedProfiles.Add(newSavedProfile);

            _dbContext.SaveChanges();

            return NoContent();
        }
        return NotFound();
    }

    [HttpDelete("{id}/unsave")]
    [Authorize]
    public IActionResult UnsaveProfile(int id)
    {

        var loggedInUser = _dbContext
                 .UserProfiles
                 .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        SavedProfile foundSavedProfile = _dbContext.SavedProfiles.SingleOrDefault(sp => sp.ProfileId == id && sp.UserProfileId == loggedInUser.Id);

        if (foundSavedProfile != null)
        {
            _dbContext.SavedProfiles.Remove(foundSavedProfile);
            _dbContext.SaveChanges();

            return NoContent();
        }

        return NotFound();


    }
    [HttpPut("{id}/primaryinfo")]
    [Authorize]
    public IActionResult EditPrimaryInfo(int id, Profile updatedProfile)
    {

        var loggedInUser = _dbContext
                 .UserProfiles
                 .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        Profile foundProfile = _dbContext.Profiles
        .SingleOrDefault(p => p.UserProfileId == id);

        if (foundProfile != null)
        {
            if (foundProfile.UserProfileId != loggedInUser.Id)
            {
                return Unauthorized();
            }

            foundProfile.City = updatedProfile.City;
            foundProfile.StateId = updatedProfile.StateId;
            foundProfile.PrimaryGenreId = updatedProfile.PrimaryGenreId;
            foundProfile.PrimaryInstrumentId = updatedProfile.PrimaryInstrumentId;
            foundProfile.SpotifyLink = updatedProfile.SpotifyLink;
            foundProfile.FacebookLink = updatedProfile.FacebookLink;
            foundProfile.InstagramLink = updatedProfile.InstagramLink;
            foundProfile.TikTokLink = updatedProfile.TikTokLink;

            _dbContext.SaveChanges();
            
            return NoContent();
        }

        return NotFound();

    }

    [HttpPut("{id}/about")]
    [Authorize]
    public IActionResult EditAbout(int id, [FromBody] string updatedAbout)
    {

        var loggedInUser = _dbContext
                 .UserProfiles
                 .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        Profile foundProfile = _dbContext.Profiles
        .SingleOrDefault(p => p.UserProfileId == id);

        if (foundProfile != null)
        {
            if (foundProfile.UserProfileId != loggedInUser.Id)
            {
                return Unauthorized();
            }

            foundProfile.About = updatedAbout;
        
            _dbContext.SaveChanges();
            
            return NoContent();
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