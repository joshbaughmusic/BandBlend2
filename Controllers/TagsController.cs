using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BandBlend.Data;
using Microsoft.EntityFrameworkCore;
using BandBlend.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.VisualBasic;

namespace BandBlend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TagController : ControllerBase
{
    private BandBlendDbContext _dbContext;

    public TagController(BandBlendDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetTags()
    {
        return Ok(_dbContext.Tags);
    }

    [HttpGet("me")]
    [Authorize]
    public IActionResult GetMyProfileTags()
    {
        var loggedInUser = _dbContext
              .UserProfiles
              .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);


        if (loggedInUser != null)
        {
            Profile foundProfile = _dbContext.Profiles.Single(p => p.UserProfileId == loggedInUser.Id);

            return Ok(_dbContext.ProfileTags.Where(pt => pt.ProfileId == foundProfile.Id));
        }
        return NotFound();
    }
 
    [HttpPut("me/edit")]
    [Authorize]
    public IActionResult EditMyProfileTags([FromBody] int[] tagIds)
    {

        if (tagIds == null || tagIds.Length != 3)
        {
            return BadRequest("You must provide exactly three tagIds in the request body.");
        }

        var loggedInUser = _dbContext
              .UserProfiles
              .Include(up => up.Profile)
              .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);


        if (loggedInUser != null)
        {
           List<ProfileTag> oldProfileTags = _dbContext.ProfileTags.Where(pt => pt.ProfileId == loggedInUser.Profile.Id).ToList();

           _dbContext.RemoveRange(oldProfileTags);

           List<ProfileTag> newProfileTags = new List<ProfileTag>();

           foreach (int id in tagIds)
           {
            ProfileTag newPt = new ProfileTag(){
                ProfileId = loggedInUser.Profile.Id,
                TagId = id
            };
            newProfileTags.Add(newPt);
           }

           _dbContext.AddRange(newProfileTags);
           _dbContext.SaveChanges();

           return NoContent();
        }
        return NotFound();
    }
}