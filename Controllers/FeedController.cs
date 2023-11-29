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
public class FeedController : ControllerBase
{
    private BandBlendDbContext _dbContext;

    public FeedController(BandBlendDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetFeedPosts(int page, int pageSize)
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<FeedUserSubscription> foundUserSubscriptions = _dbContext.FeedUserSubscriptions
            .Where(sub => sub.UserThatSubbedId == loggedInUser.Id)
            .ToList();

        List<FeedStateSubscription> foundStateSubscriptions = _dbContext.FeedStateSubscriptions
            .Where(sub => sub.UserProfileId == loggedInUser.Id)
            .ToList();

        List<FeedPrimaryGenreSubscription> foundPrimaryGenreSubscriptions = _dbContext.FeedPrimaryGenreSubscriptions
            .Where(sub => sub.UserProfileId == loggedInUser.Id)
            .ToList();

        List<FeedPrimaryInstrumentSubscription> foundPrimaryInstrumentSubscriptions = _dbContext.FeedPrimaryInstrumentSubscriptions
            .Where(sub => sub.UserProfileId == loggedInUser.Id)
            .ToList();

        var allPosts = _dbContext.Posts
            .Include(p => p.UserProfile)
            .ThenInclude(up => up.Profile)
            .OrderByDescending(p => p.Date)
            .ToList();

        var filteredPosts = allPosts
            .Where(p =>
                foundUserSubscriptions.Any(sub => sub.UserSubbedToId == p.UserProfileId) ||
                foundStateSubscriptions.Any(sub => sub.StateId == p.UserProfile.Profile.StateId) ||
                foundPrimaryGenreSubscriptions.Any(sub => sub.PrimaryGenreId == p.UserProfile.Profile.PrimaryGenreId) ||
                foundPrimaryInstrumentSubscriptions.Any(sub => sub.PrimaryInstrumentId == p.UserProfile.Profile.PrimaryInstrumentId))
            .Where(p => p.UserProfileId != loggedInUser.Id)
            .ToList();

        foreach (Post post in filteredPosts)
        {
            post.CommentCount = _dbContext.Comments.Where(c => c.PostId == post.Id).Count();
        }

        int count = filteredPosts.Count;

        var data = new
        {
            posts = filteredPosts.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
            totalCount = count
        };

        return Ok(data);
    }


}