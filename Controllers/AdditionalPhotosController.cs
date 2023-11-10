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
public class PhotoController : ControllerBase
{
    private BandBlendDbContext _dbContext;

    public PhotoController(BandBlendDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("me")]
    [Authorize]
    public IActionResult GetMyAdditionalPhotos()
    {
        var loggedInUser = _dbContext
             .UserProfiles
             .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        return Ok(_dbContext.AdditionalPictures
        .Where(ap => ap.UserProfileId == loggedInUser.Id)
        .ToList());
    }

    [HttpGet("user/{id}")]
    [Authorize]
    public IActionResult GetOtherAdditionalPhotos(int id)
    {    
        UserProfile foundUserProfile = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == id);

        if (foundUserProfile == null)
        {
            return NotFound();
        }  

        return Ok(_dbContext.AdditionalPictures
        .Where(ap => ap.UserProfileId == id)
        .ToList());
    }



}