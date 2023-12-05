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
public class AdminController : ControllerBase
{
    private BandBlendDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;


    public AdminController(BandBlendDbContext context, UserManager<IdentityUser> userManager)
    {
        _dbContext = context;
        _userManager = userManager;

    }

    [HttpGet()]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAllAdmins()
    {
        var loggedInUser = _dbContext
                        .UserProfiles
                        .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        var adminRole = _dbContext.Roles.Single(r => r.Name ==
        "Admin");

        List<string> adminUserIds = _dbContext.UserRoles
            .Where(ur => ur.RoleId == adminRole.Id)
            .Select(ur => ur.UserId)
            .Distinct()
            .ToList();

        List<UserProfile> foundAdmins = _dbContext.UserProfiles
            .Include(up => up.Profile)
            .Where(up => adminUserIds.Contains(up.IdentityUserId) && up.Id != loggedInUser.Id)
            .ToList();

        return Ok(foundAdmins);
    }

    [HttpDelete("post/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminDeletePost(int id)
    {

        Post foundPost = _dbContext.Posts.SingleOrDefault(p => p.Id == id);

        if (foundPost != null)
        {
            _dbContext.Posts.Remove(foundPost);
            _dbContext.SaveChanges();
            return NoContent();
        }

        return NotFound();
    }


    [HttpDelete("comment/{id}")]
    [Authorize(Roles = "Admin")]

    public IActionResult AdminDeleteComment(int id)
    {
        Comment foundComment = _dbContext.Comments.SingleOrDefault(p => p.Id == id);

        if (foundComment != null)
        {

            _dbContext.Comments.Remove(foundComment);
            _dbContext.SaveChanges();
            return NoContent();

        }

        return NotFound();
    }

    [HttpDelete("additionalphoto/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminDeleteAdditionalPhoto(int id)
    {

        AdditionalPicture foundAdditionalPic = _dbContext.AdditionalPictures.SingleOrDefault(ap => ap.Id == id);

        if (foundAdditionalPic == null)
        {
            return NotFound();
        }

        _dbContext.AdditionalPictures.Remove(foundAdditionalPic);
        _dbContext.SaveChanges();

        return NoContent();

    }

    [HttpDelete("profilephoto/{profileId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminDeleteProfilePhoto(int profileId)
    {

        Profile foundProfile = _dbContext.Profiles.SingleOrDefault(p => p.Id == profileId);

        if (foundProfile == null)
        {
            return NotFound();
        }

        foundProfile.ProfilePicture = "";

        _dbContext.SaveChanges();

        return NoContent();

    }

    [HttpPost("promote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminPromote(string id)
    {
        IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");

        List<IdentityUserRole<string>> foundUserRoles = _dbContext.UserRoles.Where(ur => ur.UserId == id).ToList();

        _dbContext.UserRoles.RemoveRange(foundUserRoles);

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
    public IActionResult AdminDemote(string id)
    {
        IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "User");

        List<IdentityUserRole<string>> foundUserRoles = _dbContext.UserRoles.Where(ur => ur.UserId == id).ToList();

        _dbContext.UserRoles.RemoveRange(foundUserRoles);

        _dbContext.UserRoles.Add(new IdentityUserRole<string>
        {
            RoleId = role.Id,
            UserId = id
        });
        _dbContext.SaveChanges();
        return NoContent();
    }



}