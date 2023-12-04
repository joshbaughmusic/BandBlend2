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
public class CommentController : ControllerBase
{
    private BandBlendDbContext _dbContext;


    public CommentController(BandBlendDbContext context)
    {
        _dbContext = context;

    }

    [HttpGet("{postId}")]
    [Authorize]
    public IActionResult GetCommentsForPost(int postId, int page, int pageSize)
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<BlockedAccount> userBlockedAccounts = _dbContext.BlockedAccounts.Where(ba => ba.UserProfileThatBlockedId == loggedInUser.Id).ToList();

        List<BlockedAccount> userBlockedByAccounts = _dbContext.BlockedAccounts.Where(ba => ba.BlockedUserProfileId == loggedInUser.Id).ToList();

        var blockedUserProfileIds = userBlockedAccounts.Select(ba => ba.BlockedUserProfileId).ToList();

        var blockedByUserProfileIds = userBlockedByAccounts.Select(ba => ba.UserProfileThatBlockedId).ToList();

        var query = _dbContext.Comments
        .Include(c => c.UserProfile)
        .ThenInclude(up => up.Profile)
        .Where(c => c.PostId == postId && !blockedUserProfileIds.Contains(c.UserProfileId) &&
        !blockedByUserProfileIds.Contains(c.UserProfileId))
        .OrderByDescending(p => p.Date);

        var allComments = query
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToList();

        int count = query.Count();

        var data = new
        {
            comments = allComments,
            totalCount = count
        };

        return Ok(data);
    }

    [HttpPost("{postId}/new")]
    [Authorize]
    public IActionResult CreateNewPost(int postId, [FromBody] string commentText)
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        Post foundPost = _dbContext.Posts.SingleOrDefault(p => p.Id == postId);

        if (foundPost != null)
        {
            Comment newComment = new Comment
            {
                UserProfileId = loggedInUser.Id,
                PostId = foundPost.Id,
                Body = commentText,
                Date = DateTime.Now
            };
            _dbContext.Comments.Add(newComment);
            _dbContext.SaveChanges();


            return Created($"/api/comment/{newComment.Id}", newComment);
        }
        else
        {
            return BadRequest();
        }


    }

    [HttpDelete("delete/{id}")]
    [Authorize]
    public IActionResult DeleteComment(int id)
    {
        Comment foundComment = _dbContext.Comments.SingleOrDefault(p => p.Id == id);

        if (foundComment != null)
        {
            var loggedInUser = _dbContext
                .UserProfiles
                .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (loggedInUser.Id == foundComment.UserProfileId)
            {
                _dbContext.Comments.Remove(foundComment);
                _dbContext.SaveChanges();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }

        }

        return NotFound();
    }

    [HttpPut("edit/{id}")]
    [Authorize]
    public IActionResult EditComment(int id, [FromBody] string editedCommentBody)
    {
        Comment foundComment = _dbContext.Comments.SingleOrDefault(p => p.Id == id);
        if (foundComment != null)
        {
            var loggedInUser = _dbContext
                .UserProfiles
                .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (loggedInUser.Id == foundComment.UserProfileId)
            {
                foundComment.Body = editedCommentBody;
                _dbContext.SaveChanges();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        return NotFound();
    }


}