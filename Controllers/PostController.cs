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
public class PostController : ControllerBase
{
    private BandBlendDbContext _dbContext;


    public PostController(BandBlendDbContext context)
    {
        _dbContext = context;

    }

    [HttpGet("user/{id}")]
    [Authorize]
    public IActionResult GetUserPosts(int id, int page, int pageSize)
    {

        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<BlockedAccount> userBlockedAccounts = _dbContext.BlockedAccounts.Where(ba => ba.UserProfileThatBlockedId == loggedInUser.Id).ToList();

        List<BlockedAccount> userBlockedByAccounts = _dbContext.BlockedAccounts.Where(ba => ba.BlockedUserProfileId == loggedInUser.Id).ToList();

        var blockedUserProfileIds = userBlockedAccounts.Select(ba => ba.BlockedUserProfileId).ToList();

        var blockedByUserProfileIds = userBlockedByAccounts.Select(ba => ba.UserProfileThatBlockedId).ToList();
        
        var query = _dbContext.Posts
        .Where(p => p.UserProfileId == id && !blockedUserProfileIds.Contains(p.UserProfileId) &&
        !blockedByUserProfileIds.Contains(p.UserProfileId))
        .OrderByDescending(p => p.Date);

        var allPosts = query
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToList();

        foreach (Post post in allPosts)
        {
            post.CommentCount = _dbContext.Comments.Where(c => c.PostId == post.Id &&
            !blockedUserProfileIds.Contains(c.UserProfileId) &&
            !blockedByUserProfileIds.Contains(c.UserProfileId)).Count();
        }

        int count = query.Count();

        var data = new
        {
            posts = allPosts,
            totalCount = count
        };

        return Ok(data);
    }

    [HttpPost("new")]
    [Authorize]
    public IActionResult CreateNewPost([FromBody] string postText)
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        Post newPost = new Post
        {
            UserProfileId = loggedInUser.Id,
            Body = postText,
            Date = DateTime.Now
        };

        _dbContext.Posts.Add(newPost);
        _dbContext.SaveChanges();

        return Created($"/api/post/{newPost.Id}", newPost);

    }

    [HttpDelete("delete/{id}")]
    [Authorize]
    public IActionResult DeletePost(int id)
    {
        Post foundPost = _dbContext.Posts.SingleOrDefault(p => p.Id == id);

        if (foundPost != null)
        {
            var loggedInUser = _dbContext
                .UserProfiles
                .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (loggedInUser.Id == foundPost.UserProfileId)
            {

                List<PostLike> foundPostLikes = _dbContext.PostLikes.Where(pl => pl.PostId == foundPost.Id).ToList();

                List<Comment> foundComments = _dbContext.Comments.Where(c => c.PostId == foundPost.Id).ToList();

                List<CommentLike> foundCommentLikes = new List<CommentLike>();

                foreach (Comment c in foundComments)
                {
                    List<CommentLike> commentLikes = _dbContext.CommentLikes.Where(cl => cl.CommentId == c.Id).ToList();

                    foundCommentLikes.AddRange(commentLikes);
                }

                _dbContext.PostLikes.RemoveRange(foundPostLikes);
                _dbContext.Comments.RemoveRange(foundComments);
                _dbContext.CommentLikes.RemoveRange(foundCommentLikes);
                _dbContext.Posts.Remove(foundPost);
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
    public IActionResult EditPost(int id, [FromBody] string editedPostBody)
    {
        Post foundPost = _dbContext.Posts.SingleOrDefault(p => p.Id == id);
        if (foundPost != null)
        {
            var loggedInUser = _dbContext
                .UserProfiles
                .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (loggedInUser.Id == foundPost.UserProfileId)
            {
                foundPost.Body = editedPostBody;
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