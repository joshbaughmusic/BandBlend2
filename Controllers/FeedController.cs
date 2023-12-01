using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BandBlend.Data;
using Microsoft.EntityFrameworkCore;
using BandBlend.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Runtime.InteropServices;

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

    [HttpGet("states")]
    [Authorize]
    public IActionResult GetFeedStateSubscriptions()
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<FeedStateSubscription> foundFeedStateSubscriptions = _dbContext.FeedStateSubscriptions
         .Include(sub => sub.State)
        .Where(sub => sub.UserProfileId == loggedInUser.Id)
        .ToList();

        return Ok(foundFeedStateSubscriptions);
    }

    [HttpDelete("states/{stateId}")]
    [Authorize]
    public IActionResult DeleteFeedStateSubscriptions(int stateId)
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        FeedStateSubscription foundFeedStateSubscription = _dbContext.FeedStateSubscriptions
        .SingleOrDefault(sub => sub.StateId == stateId && sub.UserProfileId == loggedInUser.Id);

        if (foundFeedStateSubscription == null)
        {
            return NotFound();
        }

        _dbContext.FeedStateSubscriptions.Remove(foundFeedStateSubscription);

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPost("states")]
    [Authorize]
    public IActionResult CreateFeedStateSubscriptions([FromBody] int[] stateIds)
    {

        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<FeedStateSubscription> matchedFeedStateSubscriptions = _dbContext.FeedStateSubscriptions
        .Where(sub => sub.UserProfileId == loggedInUser.Id)
        .ToList();

        foreach (int stateId in stateIds)
        {
            if (matchedFeedStateSubscriptions.Any(sub => sub.StateId == stateId))
            {
                return BadRequest();
            }
            else
            {
                FeedStateSubscription newStateSub = new FeedStateSubscription()
                {
                    UserProfileId = loggedInUser.Id,
                    StateId = stateId,
                    Date = DateTime.Now
                };

                _dbContext.Add(newStateSub);
            }
        }

        _dbContext.SaveChanges();

        return NoContent();

    }

    [HttpGet("primarygenres")]
    [Authorize]
    public IActionResult GetFeedPrimaryGenreSubscriptions()
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<FeedPrimaryGenreSubscription> foundFeedPrimaryGenreSubscriptions = _dbContext.FeedPrimaryGenreSubscriptions
        .Include(sub => sub.PrimaryGenre)
        .Where(sub => sub.UserProfileId == loggedInUser.Id)
        .ToList();

        return Ok(foundFeedPrimaryGenreSubscriptions);
    }

    [HttpDelete("primaryGenres/{primaryGenreId}")]
    [Authorize]
    public IActionResult DeleteFeedPrimaryGenreSubscriptions(int primaryGenreId)
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        FeedPrimaryGenreSubscription foundFeedPrimaryGenreSubscription = _dbContext.FeedPrimaryGenreSubscriptions
        .SingleOrDefault(sub => sub.PrimaryGenreId == primaryGenreId && sub.UserProfileId == loggedInUser.Id);

        if (foundFeedPrimaryGenreSubscription == null)
        {
            return NotFound();
        }

        _dbContext.FeedPrimaryGenreSubscriptions.Remove(foundFeedPrimaryGenreSubscription);

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPost("primaryGenres")]
    [Authorize]
    public IActionResult CreateFeedPrimaryGenreSubscriptions([FromBody] int[] primaryGenreIds)
    {

        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<FeedPrimaryGenreSubscription> matchedFeedPrimaryGenreSubscriptions = _dbContext.FeedPrimaryGenreSubscriptions
        .Where(sub => sub.UserProfileId == loggedInUser.Id)
        .ToList();

        foreach (int primaryGenreId in primaryGenreIds)
        {
            if (matchedFeedPrimaryGenreSubscriptions.Any(sub => sub.PrimaryGenreId == primaryGenreId))
            {
                return BadRequest();
            }
            else
            {
                FeedPrimaryGenreSubscription newPrimaryGenreSub = new FeedPrimaryGenreSubscription()
                {
                    UserProfileId = loggedInUser.Id,
                    PrimaryGenreId = primaryGenreId,
                    Date = DateTime.Now
                };

                _dbContext.FeedPrimaryGenreSubscriptions.Add(newPrimaryGenreSub);
            }
        }

        _dbContext.SaveChanges();

        return NoContent();

    }

    [HttpGet("primaryinstruments")]
    [Authorize]
    public IActionResult GetFeedPrimaryInstrumentSubscriptions()
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<FeedPrimaryInstrumentSubscription> foundFeedPrimaryInstrumentSubscriptions = _dbContext.FeedPrimaryInstrumentSubscriptions
         .Include(sub => sub.PrimaryInstrument)
        .Where(sub => sub.UserProfileId == loggedInUser.Id)
        .ToList();

        return Ok(foundFeedPrimaryInstrumentSubscriptions);
    }

    [HttpDelete("primaryInstruments/{primaryInstrumentId}")]
    [Authorize]
    public IActionResult DeleteFeedPrimaryInstrumentSubscriptions(int primaryInstrumentId)
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        FeedPrimaryInstrumentSubscription foundFeedPrimaryInstrumentSubscriptions = _dbContext.FeedPrimaryInstrumentSubscriptions
        .SingleOrDefault(sub => sub.PrimaryInstrumentId == primaryInstrumentId && sub.UserProfileId == loggedInUser.Id);

        if (foundFeedPrimaryInstrumentSubscriptions == null)
        {
            return NotFound();
        }

        _dbContext.FeedPrimaryInstrumentSubscriptions.Remove(foundFeedPrimaryInstrumentSubscriptions);

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPost("primaryInstruments")]
    [Authorize]
    public IActionResult CreateFeedPrimaryInstrumentSubscriptions([FromBody] int[] primaryInstrumentIds)
    {

        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<FeedPrimaryInstrumentSubscription> matchedFeedPrimaryInstrumentSubscriptions = _dbContext.FeedPrimaryInstrumentSubscriptions
        .Where(sub => sub.UserProfileId == loggedInUser.Id)
        .ToList();

        foreach (int primaryInstrumentId in primaryInstrumentIds)
        {
            if (matchedFeedPrimaryInstrumentSubscriptions.Any(sub => sub.PrimaryInstrumentId == primaryInstrumentId))
            {
                return BadRequest();
            }
            else
            {
                FeedPrimaryInstrumentSubscription newPrimaryInstrumentSub = new FeedPrimaryInstrumentSubscription()
                {
                    UserProfileId = loggedInUser.Id,
                    PrimaryInstrumentId = primaryInstrumentId,
                    Date = DateTime.Now
                };

                _dbContext.FeedPrimaryInstrumentSubscriptions.Add(newPrimaryInstrumentSub);
            }
        }

        _dbContext.SaveChanges();

        return NoContent();

    }

    [HttpGet("users")]
    [Authorize]
    public IActionResult GetFeedUserSubscriptions()
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<FeedUserSubscription> foundFeedUserSubscriptions = _dbContext.FeedUserSubscriptions
         .Include(sub => sub.UserSubbedTo)
        .Where(sub => sub.UserThatSubbedId == loggedInUser.Id)
        .ToList();

        return Ok(foundFeedUserSubscriptions);
    }

    [HttpDelete("users/{userId}")]
    [Authorize]
    public IActionResult DeleteFeedUserSubscriptions(int userId)
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        FeedUserSubscription foundFeedUserSubscriptions = _dbContext.FeedUserSubscriptions
        .SingleOrDefault(sub => sub.UserSubbedToId == userId && sub.UserThatSubbedId == loggedInUser.Id);

        if (foundFeedUserSubscriptions == null)
        {
            return NotFound();
        }

        _dbContext.FeedUserSubscriptions.Remove(foundFeedUserSubscriptions);

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPost("users")]
    [Authorize]
    public IActionResult CreateFeedUserSubscriptions([FromBody] int userId)
    {

        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<FeedUserSubscription> matchedFeedUserSubscriptions = _dbContext.FeedUserSubscriptions
        .Where(sub => sub.UserSubbedToId == loggedInUser.Id)
        .ToList();

        FeedUserSubscription newUserSub = new FeedUserSubscription()
        {
            UserThatSubbedId = loggedInUser.Id,
            UserSubbedToId = userId,
            Date = DateTime.Now
        };

        _dbContext.Add(newUserSub);

        _dbContext.SaveChanges();

        return NoContent();

    }


}