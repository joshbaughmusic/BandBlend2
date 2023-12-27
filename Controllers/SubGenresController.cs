using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BandBlend.Data;
using Microsoft.EntityFrameworkCore;
using BandBlend.Models;
using System.Security.Claims;

namespace BandBlend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class SubGenreController : ControllerBase
{
    private BandBlendDbContext _dbContext;

    public SubGenreController(BandBlendDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public IActionResult GetSubGenres()
    {
        return Ok(_dbContext.SubGenres);
    }

    [HttpGet("me")]
    [Authorize]
    public IActionResult GetMyProfileSubGenres()
    {
        var loggedInUser = _dbContext
              .UserProfiles
              .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);


        if (loggedInUser != null)
        {
            Profile foundProfile = _dbContext.Profiles.Single(p => p.UserProfileId == loggedInUser.Id);

            return Ok(_dbContext.ProfileSubGenres.Where(pt => pt.ProfileId == foundProfile.Id));
        }
        return NotFound();
    }
 
    [HttpPut("me/edit")]
    [Authorize]
    public IActionResult EditMyProfileSubGenres([FromBody] int[] subGenreIds)
    {

        if (subGenreIds == null || subGenreIds.Length != 3)
        {
            return BadRequest("You must provide exactly three subGenreIds in the request body.");
        }

        var loggedInUser = _dbContext
              .UserProfiles
              .Include(up => up.Profile)
              .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);


        if (loggedInUser != null)
        {
           List<ProfileSubGenre> oldProfileSubGenres = _dbContext.ProfileSubGenres.Where(pt => pt.ProfileId == loggedInUser.Profile.Id).ToList();

           _dbContext.RemoveRange(oldProfileSubGenres);

           List<ProfileSubGenre> newProfileSubGenres = new List<ProfileSubGenre>();

           foreach (int id in subGenreIds)
           {
            ProfileSubGenre newPt = new ProfileSubGenre(){
                ProfileId = loggedInUser.Profile.Id,
                SubGenreId = id
            };
            newProfileSubGenres.Add(newPt);
           }

           _dbContext.AddRange(newProfileSubGenres);
           _dbContext.SaveChanges();

           return NoContent();
        }
        return NotFound();
    }
}