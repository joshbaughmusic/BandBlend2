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
public class CommentLikeController : ControllerBase
{
    private BandBlendDbContext _dbContext;

    public CommentLikeController(BandBlendDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("{commentId}")]
    [Authorize]
    public IActionResult GetCommentLike(int commentId)
    {

        Comment foundComment = _dbContext.Comments.SingleOrDefault(p => p.Id == commentId);

        if (foundComment == null)
        {
            return NotFound();
        }
        return Ok(_dbContext.CommentLikes
        .Include(pl => pl.UserProfile)
        .ThenInclude(up => up.Profile)
        .Where(pl => pl.CommentId == commentId)
        .ToList());
    }

    [HttpPost("{commentId}")]
    [Authorize]
    public IActionResult NewCommentLike(int commentId)
    {

        Comment foundComment = _dbContext.Comments.SingleOrDefault(p => p.Id == commentId);

        if (foundComment == null)
        {
            return NotFound();
        }

        var loggedInUser = _dbContext
               .UserProfiles
               .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        if (foundComment.UserProfileId == loggedInUser.Id)
        {
            return BadRequest();
        }

        CommentLike newCommentLike = new CommentLike()
        {
            UserProfileId = loggedInUser.Id,
            CommentId = commentId,
            Date = DateTime.Now
        };

        _dbContext.CommentLikes.Add(newCommentLike);
        _dbContext.SaveChanges();

        return Created($"/api/commentlike/{newCommentLike.Id}", newCommentLike);
    }

    [HttpDelete("{commentId}")]
    [Authorize]
    public IActionResult DeleteCommentLike(int commentId)
    {

        Comment foundComment = _dbContext.Comments.SingleOrDefault(p => p.Id == commentId);

        if (foundComment == null)
        {
            return NotFound();
        }

        var loggedInUser = _dbContext
               .UserProfiles
               .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        if (foundComment.UserProfileId == loggedInUser.Id)
        {
            return BadRequest();
        }

        CommentLike foundCommentLike = _dbContext.CommentLikes.SingleOrDefault(pl => pl.UserProfileId == loggedInUser.Id && pl.CommentId == commentId);

        if (foundCommentLike == null)
        {
            return NotFound();
        }

        _dbContext.CommentLikes.Remove(foundCommentLike);
        _dbContext.SaveChanges();

        return NoContent();
    }

}