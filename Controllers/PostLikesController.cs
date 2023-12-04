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
public class PostLikeController : ControllerBase
{
    private BandBlendDbContext _dbContext;

    public PostLikeController(BandBlendDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("{postId}")]
    [Authorize]
    public IActionResult GetPostLike(int postId)
    {
        var loggedInUser = _dbContext
                   .UserProfiles
                   .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<BlockedAccount> userBlockedAccounts = _dbContext.BlockedAccounts.Where(ba => ba.UserProfileThatBlockedId == loggedInUser.Id).ToList();

        List<BlockedAccount> userBlockedByAccounts = _dbContext.BlockedAccounts.Where(ba => ba.BlockedUserProfileId == loggedInUser.Id).ToList();

        var blockedUserProfileIds = userBlockedAccounts.Select(ba => ba.BlockedUserProfileId).ToList();

        var blockedByUserProfileIds = userBlockedByAccounts.Select(ba => ba.UserProfileThatBlockedId).ToList();

        Post foundPost = _dbContext.Posts.SingleOrDefault(p => p.Id == postId);

        if (foundPost == null)
        {
            return NotFound();
        }
        return Ok(_dbContext.PostLikes
        .Include(pl => pl.UserProfile)
        .ThenInclude(up => up.Profile)
        .Where(pl => pl.PostId == postId && !blockedUserProfileIds.Contains(pl.UserProfileId) &&
        !blockedByUserProfileIds.Contains(pl.UserProfileId))
        .ToList());
    }

    [HttpPost("{postId}")]
    [Authorize]
    public IActionResult NewPostLike(int postId)
    {

        Post foundPost = _dbContext.Posts.SingleOrDefault(p => p.Id == postId);

        if (foundPost == null)
        {
            return NotFound();
        }

        var loggedInUser = _dbContext
               .UserProfiles
               .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        if (foundPost.UserProfileId == loggedInUser.Id) {
            return BadRequest();
        }

        PostLike newPostLike = new PostLike() {
            UserProfileId = loggedInUser.Id,
            PostId = postId,
            Date = DateTime.Now
        };

        _dbContext.PostLikes.Add(newPostLike);
        _dbContext.SaveChanges();

        return Created($"/api/postlike/{newPostLike.Id}", newPostLike);
    }

    [HttpDelete("{postId}")]
    [Authorize]
    public IActionResult DeletePostLike(int postId)
    {

        Post foundPost = _dbContext.Posts.SingleOrDefault(p => p.Id == postId);

        if (foundPost == null)
        {
            return NotFound();
        }

        var loggedInUser = _dbContext
               .UserProfiles
               .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        if (foundPost.UserProfileId == loggedInUser.Id) {
            return BadRequest();
        }

        PostLike foundPostLike = _dbContext.PostLikes.SingleOrDefault(pl => pl.UserProfileId == loggedInUser.Id && pl.PostId == postId);

        if (foundPostLike == null)
        {
            return NotFound();
        }

        _dbContext.PostLikes.Remove(foundPostLike);
        _dbContext.SaveChanges();

        return NoContent();
    }

}