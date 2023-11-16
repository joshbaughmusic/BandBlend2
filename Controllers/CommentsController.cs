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
        var query = _dbContext.Comments
        .Include(c => c.UserProfile)
        .ThenInclude(up => up.Profile)
        .Where(c => c.PostId == postId)
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
    public IActionResult CreateNewPost(int postId, [FromBody] string postText)
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