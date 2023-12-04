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

    [HttpPost("promote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminPromote(string id)
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
    public IActionResult AdminDemote(string id)
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