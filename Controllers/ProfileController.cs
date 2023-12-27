using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BandBlend.Data;
using Microsoft.EntityFrameworkCore;
using BandBlend.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


namespace BandBlend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private BandBlendDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;


    public ProfileController(BandBlendDbContext context, UserManager<IdentityUser> userManager)
    {
        _dbContext = context;
        _userManager = userManager;

    }

    [HttpGet]
    public IActionResult GetAllProfiles(string search = null, string filter = null, string sort = null, int page = 1, int pageSize = 10)
    {

        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<BlockedAccount> userBlockedAccounts = _dbContext.BlockedAccounts.Where(ba => ba.UserProfileThatBlockedId == loggedInUser.Id).ToList();

        List<BlockedAccount> userBlockedByAccounts = _dbContext.BlockedAccounts.Where(ba => ba.BlockedUserProfileId == loggedInUser.Id).ToList();

        var blockedUserProfileIds = userBlockedAccounts.Select(ba => ba.BlockedUserProfileId).ToList();

        var blockedByUserProfileIds = userBlockedByAccounts.Select(ba => ba.UserProfileThatBlockedId).ToList();

        List<SavedProfile> savedProfilesByUser = _dbContext.SavedProfiles.Where(sp => sp.UserProfileId == loggedInUser.Id).ToList();


        var query = _dbContext.UserProfiles
            .Include(up => up.Profile)
                .ThenInclude(p => p.PrimaryGenre)
            .Include(up => up.Profile)
                .ThenInclude(p => p.PrimaryInstrument)
            .Include(up => up.Profile)
                .ThenInclude(p => p.State)
            .Include(up => up.Profile)
                .ThenInclude(p => p.ProfileSubGenres)
                .ThenInclude(ps => ps.SubGenre)
            .Include(up => up.Profile)
                .ThenInclude(p => p.ProfileTags)
                .ThenInclude(pt => pt.Tag)
            .Where(up => up.Id != loggedInUser.Id && !blockedUserProfileIds.Contains(up.Id) &&
            !blockedByUserProfileIds.Contains(up.Id) &&
            !up.AccountBanned);

        foreach (UserProfile up in query)
        {
            if (savedProfilesByUser.Any(sp => sp.ProfileId == up.Profile.Id))
            {
                up.Profile.SavedProfile = savedProfilesByUser.Single(sp => sp.ProfileId == up.Profile.Id);
            }

        }

        // Apply filters based on the provided parameters
        if (search != "undefined" && search != null)
        {
            query = query
            .Where(up => up.Name.ToLower().Contains(search.ToLower()) ||
            up.Profile.PrimaryGenre.Name.ToLower().Contains(search.ToLower()) ||
            up.Profile.PrimaryInstrument.Name.ToLower().Contains(search.ToLower()) ||
            up.Profile.City.ToLower().Contains(search.ToLower()) ||
            up.Profile.State.Name.ToLower().Contains(search.ToLower())
            );
        }

        if (filter != "undefined" && filter != null)
        {
            if (filter == "saved")
            {
                query = query
                .Where(up => up.Profile.SavedProfile != null);
            }
            if (filter == "bands")
            {
                query = query
                .Where(up => up.IsBand == true);
            }
            if (filter == "musicians")
            {
                query = query
                .Where(up => up.IsBand == false);
            }
        }

        if (sort != "undefined" && sort != null)
        {
            if (sort == "naz")
            {
                query = query.OrderBy(up => up.Name);
            }
            if (sort == "nza")
            {
                query = query.OrderByDescending(up => up.Name);
            }
            if (sort == "caz")
            {
                query = query.OrderBy(up => up.Profile.City);
            }
            if (sort == "cza")
            {
                query = query.OrderByDescending(up => up.Profile.City);
            }
            if (sort == "saz")
            {
                query = query.OrderBy(up => up.Profile.State.Name);
            }
            if (sort == "sza")
            {
                query = query.OrderByDescending(up => up.Profile.State.Name);
            }
            if (sort == "piaz")
            {
                query = query.OrderBy(up => up.Profile.PrimaryInstrument.Name);
            }
            if (sort == "piza")
            {
                query = query.OrderByDescending(up => up.Profile.PrimaryInstrument.Name);
            }
            if (sort == "pgaz")
            {
                query = query.OrderBy(up => up.Profile.PrimaryGenre.Name);
            }
            if (sort == "pgza")
            {
                query = query.OrderByDescending(up => up.Profile.PrimaryGenre.Name);
            }

        }

        var allProfiles = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        int count = query.Count();

        var data = new
        {
            profiles = allProfiles,
            totalCount = count
        };

        return Ok(data);
    }


    [HttpGet("me")]
    [Authorize]
    public IActionResult GetCurrentUserProfile()
    {
        var loggedInUser = _dbContext
             .UserProfiles
             .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);


        if (loggedInUser != null)
        {
            UserProfile foundUserProfile = _dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .Select(up => new UserProfile
        {
            Id = up.Id,
            Name = up.Name,
            Email = up.IdentityUser.Email,
            IsBand = up.IsBand,
            AccountBanned = up.AccountBanned,
            IdentityUserId = up.IdentityUserId,
            Roles = _dbContext.UserRoles
                .Where(ur => ur.UserId == up.IdentityUserId)
                .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
                .ToList()
        })
        .SingleOrDefault(up => up.Id == loggedInUser.Id);

            Profile matchedProfile = _dbContext.Profiles
            .Include(p => p.State)
            .Include(p => p.PrimaryInstrument)
            .Include(p => p.PrimaryGenre)
            .SingleOrDefault(p => p.UserProfileId == foundUserProfile.Id);

            List<ProfileTag> matchedProfileTags = _dbContext.ProfileTags
            .Include(pt => pt.Tag)
            .Where(pt => pt.ProfileId == matchedProfile.Id)
            .ToList();

            List<ProfileSubGenre> matchedProfileSubGenres = _dbContext.ProfileSubGenres
            .Include(pt => pt.SubGenre)
            .Where(ps => ps.ProfileId == matchedProfile.Id)
            .ToList();

            matchedProfile.ProfileTags = matchedProfileTags;
            matchedProfile.ProfileSubGenres = matchedProfileSubGenres;

            foundUserProfile.Profile = matchedProfile;

            foundUserProfile.Profile.PostCount = _dbContext.Posts.Where(p => p.UserProfileId == loggedInUser.Id).Count();

            foundUserProfile.Profile.PhotoCount = _dbContext.AdditionalPictures.Where(ap => ap.UserProfileId == loggedInUser.Id).Count();

            return Ok(foundUserProfile);
        }
        return NotFound();
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetOtherUserProfile(int id)
    {
        var loggedInUser = _dbContext
             .UserProfiles
             .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);
        if (loggedInUser.Id == id)
        {
            return BadRequest();
        }

        List<BlockedAccount> userBlockedAccounts = _dbContext.BlockedAccounts.Where(ba => ba.UserProfileThatBlockedId == loggedInUser.Id).ToList();

        List<BlockedAccount> userBlockedByAccounts = _dbContext.BlockedAccounts.Where(ba => ba.BlockedUserProfileId == loggedInUser.Id).ToList();

        var blockedUserProfileIds = userBlockedAccounts.Select(ba => ba.BlockedUserProfileId).ToList();

        var blockedByUserProfileIds = userBlockedByAccounts.Select(ba => ba.UserProfileThatBlockedId).ToList();

        UserProfile foundUserProfile = _dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .Select(up => new UserProfile
        {
            Id = up.Id,
            Name = up.Name,
            Email = up.IdentityUser.Email,
            IsBand = up.IsBand,
            AccountBanned = up.AccountBanned,
            IdentityUserId = up.IdentityUserId,
            Roles = _dbContext.UserRoles
                .Where(ur => ur.UserId == up.IdentityUserId)
                .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
                .ToList()
        })
        .SingleOrDefault(up => up.Id == id);

        if (foundUserProfile == null)
        {
            return Unauthorized();
        }

        if (blockedUserProfileIds.Contains(id) || blockedByUserProfileIds.Contains(id) ||
            foundUserProfile.AccountBanned)
        {
            return Unauthorized();
        }


        if (foundUserProfile != null)
        {

            Profile matchedProfile = _dbContext.Profiles
            .Include(p => p.State)
            .Include(p => p.PrimaryInstrument)
            .Include(p => p.PrimaryGenre)
            .SingleOrDefault(p => p.UserProfileId == foundUserProfile.Id);

            List<ProfileTag> matchedProfileTags = _dbContext.ProfileTags
            .Include(pt => pt.Tag)
            .Where(pt => pt.ProfileId == matchedProfile.Id)
            .ToList();

            List<ProfileSubGenre> matchedProfileSubGenres = _dbContext.ProfileSubGenres
            .Include(pt => pt.SubGenre)
            .Where(ps => ps.ProfileId == matchedProfile.Id)
            .ToList();

            matchedProfile.ProfileTags = matchedProfileTags;
            matchedProfile.ProfileSubGenres = matchedProfileSubGenres;
            foundUserProfile.Profile = matchedProfile;

            foundUserProfile.Profile.PostCount = _dbContext.Posts.Where(p => p.UserProfileId == id).Count();

            foundUserProfile.Profile.PhotoCount = _dbContext.AdditionalPictures.Where(ap => ap.UserProfileId == id).Count();

            List<SavedProfile> savedProfilesByUser = _dbContext.SavedProfiles.Where(sp => sp.UserProfileId == loggedInUser.Id).ToList();

            if (savedProfilesByUser.Any(sp => sp.ProfileId == foundUserProfile.Profile.Id))
            {
                foundUserProfile.Profile.SavedProfile = savedProfilesByUser.Single(sp => sp.ProfileId == foundUserProfile.Profile.Id);
            }

            return Ok(foundUserProfile);
        }
        return NotFound();
    }

    [HttpPost("{id}/save")]
    [Authorize]
    public IActionResult SaveProfile(int id)
    {
        Profile foundProfile = _dbContext.Profiles.SingleOrDefault(p => p.Id == id);

        if (foundProfile != null)
        {
            var loggedInUser = _dbContext
                 .UserProfiles
                 .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            SavedProfile newSavedProfile = new SavedProfile
            {
                ProfileId = id,
                UserProfileId = loggedInUser.Id
            };

            _dbContext.SavedProfiles.Add(newSavedProfile);

            _dbContext.SaveChanges();

            return NoContent();
        }
        return NotFound();
    }

    [HttpDelete("{id}/unsave")]
    [Authorize]
    public IActionResult UnsaveProfile(int id)
    {

        var loggedInUser = _dbContext
                 .UserProfiles
                 .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        SavedProfile foundSavedProfile = _dbContext.SavedProfiles.SingleOrDefault(sp => sp.ProfileId == id && sp.UserProfileId == loggedInUser.Id);

        if (foundSavedProfile != null)
        {
            _dbContext.SavedProfiles.Remove(foundSavedProfile);
            _dbContext.SaveChanges();

            return NoContent();
        }

        return NotFound();


    }
    [HttpPut("{id}/primaryinfo")]
    [Authorize]
    public IActionResult EditPrimaryInfo(int id, Profile updatedProfile)
    {

        var loggedInUser = _dbContext
                 .UserProfiles
                 .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        Profile foundProfile = _dbContext.Profiles
        .SingleOrDefault(p => p.UserProfileId == id);

        if (foundProfile != null)
        {
            if (foundProfile.UserProfileId != loggedInUser.Id)
            {
                return Unauthorized();
            }

            foundProfile.City = updatedProfile.City;
            foundProfile.StateId = updatedProfile.StateId;
            foundProfile.PrimaryGenreId = updatedProfile.PrimaryGenreId;
            foundProfile.PrimaryInstrumentId = updatedProfile.PrimaryInstrumentId;
            foundProfile.SpotifyLink = updatedProfile.SpotifyLink;
            foundProfile.FacebookLink = updatedProfile.FacebookLink;
            foundProfile.InstagramLink = updatedProfile.InstagramLink;
            foundProfile.TikTokLink = updatedProfile.TikTokLink;

            _dbContext.SaveChanges();

            return NoContent();
        }

        return NotFound();

    }

    [HttpPut("{id}/about")]
    [Authorize]
    public IActionResult EditAbout(int id, [FromBody] string updatedAbout)
    {

        var loggedInUser = _dbContext
                 .UserProfiles
                 .Include(up => up.Profile)
                 .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        Profile foundProfile = _dbContext.Profiles
        .SingleOrDefault(p => p.UserProfileId == id);

        if (foundProfile != null)
        {
            if (foundProfile.UserProfileId != loggedInUser.Id)
            {
                return Unauthorized();
            }

            foundProfile.About = updatedAbout;

            _dbContext.SaveChanges();

            return NoContent();
        }

        return NotFound();

    }

    [HttpPut("profilepicture")]
    [Authorize]
    public IActionResult EditProfilePicture([FromBody] string url)
    {
        var loggedInUser = _dbContext
             .UserProfiles
             .Include(up => up.Profile)
             .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        loggedInUser.Profile.ProfilePicture = url;

        _dbContext.SaveChanges();

        return NoContent();

    }

    [HttpGet("search/{searchTerms}")]
    [Authorize]
    public IActionResult SearchForUserProfiles(string searchTerms)
    {
        var loggedInUser = _dbContext
             .UserProfiles
             .Include(up => up.Profile)
             .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<BlockedAccount> userBlockedAccounts = _dbContext.BlockedAccounts.Where(ba => ba.UserProfileThatBlockedId == loggedInUser.Id).ToList();

        List<BlockedAccount> userBlockedByAccounts = _dbContext.BlockedAccounts.Where(ba => ba.BlockedUserProfileId == loggedInUser.Id).ToList();

        var blockedUserProfileIds = userBlockedAccounts.Select(ba => ba.BlockedUserProfileId).ToList();

        var blockedByUserProfileIds = userBlockedByAccounts.Select(ba => ba.UserProfileThatBlockedId).ToList();


        List<UserProfile> foundUserProfiles = _dbContext.UserProfiles
        .Include(up => up.Profile)
        .ThenInclude(p => p.PrimaryGenre)
        .Include(up => up.Profile)
        .ThenInclude(p => p.PrimaryInstrument)
        .Include(up => up.Profile)
        .ThenInclude(p => p.State)
        .Where(up =>
        up.Name.ToLower().Contains(searchTerms.ToLower()) ||
        up.Profile.PrimaryGenre.Name.ToLower().Contains(searchTerms.ToLower()) ||
        up.Profile.PrimaryInstrument.Name.ToLower().Contains(searchTerms.ToLower()) ||
        up.Profile.State.Name.ToLower().Contains(searchTerms.ToLower()) ||
        up.Profile.City.ToLower().Contains(searchTerms.ToLower())
        )
        .Where(up => up.Id != loggedInUser.Id && !blockedUserProfileIds.Contains(up.Id) &&
        !blockedByUserProfileIds.Contains(up.Id) &&
            !up.AccountBanned)
        .Take(10)
        .ToList();

        return Ok(foundUserProfiles);

    }

    [HttpDelete("delete")]
    [Authorize]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public async Task<IActionResult> DeleteMyAccount()
    {
        var loggedInUser = _dbContext
             .UserProfiles
             .Include(up => up.Profile)
             .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        var user = await _userManager.FindByIdAsync(loggedInUser.IdentityUserId);

        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        UserProfile foundUserProfile = _dbContext.UserProfiles
        .Include(up => up.Profile)
        .SingleOrDefault(up => up.IdentityUserId == loggedInUser.IdentityUserId);

        if (user == null || foundUserProfile == null)
        {
            return NotFound();
        }

        var roles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, roles);

        var claims = await _userManager.GetClaimsAsync(user);
        await _userManager.RemoveClaimsAsync(user, claims);

        var logins = await _userManager.GetLoginsAsync(user);
        foreach (var login in logins)
        {
            await _userManager.RemoveLoginAsync(user, login.LoginProvider, login.ProviderKey);
        }

        Profile foundProfile = _dbContext.Profiles.SingleOrDefault(p => p.UserProfileId == foundUserProfile.Id);
        _dbContext.Profiles.Remove(foundProfile);

        List<AdditionalPicture> foundAdditionalPictures = _dbContext.AdditionalPictures.Where(ap => ap.UserProfileId == foundUserProfile.Id).ToList();
        _dbContext.AdditionalPictures.RemoveRange(foundAdditionalPictures);

        List<ProfileTag> foundProfileTags = _dbContext.ProfileTags.Where(pt => pt.ProfileId == foundUserProfile.Profile.Id).ToList();
        _dbContext.ProfileTags.RemoveRange(foundProfileTags);

        List<ProfileSubGenre> foundProfileSubGenres = _dbContext.ProfileSubGenres.Where(ps => ps.ProfileId == foundUserProfile.Profile.Id).ToList();
        _dbContext.ProfileSubGenres.RemoveRange(foundProfileSubGenres);

        List<Post> foundPosts = _dbContext.Posts.Where(p => p.UserProfileId == foundUserProfile.Id).ToList();
        _dbContext.Posts.RemoveRange(foundPosts);

        List<Comment> foundComments = _dbContext.Comments.Where(c => c.UserProfileId == foundUserProfile.Id).ToList();
        _dbContext.Comments.RemoveRange(foundComments);

        List<PostLike> foundPostLikes = _dbContext.PostLikes.Where(pl => pl.UserProfileId == foundUserProfile.Id).ToList();
        _dbContext.PostLikes.RemoveRange(foundPostLikes);

        List<CommentLike> foundCommentLikes = _dbContext.CommentLikes.Where(pl => pl.UserProfileId == foundUserProfile.Id).ToList();
        _dbContext.CommentLikes.RemoveRange(foundCommentLikes);

        List<BlockedAccount> foundBlockedAccounts = _dbContext.BlockedAccounts.Where(ba => ba.BlockedUserProfileId == foundUserProfile.Id || ba.UserProfileThatBlockedId == foundUserProfile.Id).ToList();
        _dbContext.BlockedAccounts.RemoveRange(foundBlockedAccounts);

        List<FeedUserSubscription> foundFeedUserSubscriptions = _dbContext.FeedUserSubscriptions.Where(us => us.UserThatSubbedId == foundUserProfile.Id || us.UserSubbedToId == foundUserProfile.Id).ToList();
        _dbContext.FeedUserSubscriptions.RemoveRange(foundFeedUserSubscriptions);

        List<FeedStateSubscription> foundFeedStateSubscriptions = _dbContext.FeedStateSubscriptions.Where(ss => ss.UserProfileId == foundUserProfile.Id).ToList();
        _dbContext.FeedStateSubscriptions.RemoveRange(foundFeedStateSubscriptions);

        List<FeedPrimaryGenreSubscription> foundFeedPrimaryGenreSubscriptions = _dbContext.FeedPrimaryGenreSubscriptions.Where(pg => pg.UserProfileId == foundUserProfile.Id).ToList();
        _dbContext.FeedPrimaryGenreSubscriptions.RemoveRange(foundFeedPrimaryGenreSubscriptions);

        List<FeedPrimaryInstrumentSubscription> foundFeedPrimaryInstrumentSubscriptions = _dbContext.FeedPrimaryInstrumentSubscriptions.Where(pi => pi.UserProfileId == foundUserProfile.Id).ToList();
        _dbContext.FeedPrimaryInstrumentSubscriptions.RemoveRange(foundFeedPrimaryInstrumentSubscriptions);

        List<SavedProfile> foundSavedProfiles = _dbContext.SavedProfiles.Where(pi => pi.UserProfileId == foundUserProfile.Id || pi.ProfileId == foundUserProfile.Profile.Id).ToList();
        _dbContext.SavedProfiles.RemoveRange(foundSavedProfiles);

        List<Message> foundMessages = _dbContext.Messages.Where(m => m.SenderId == foundUserProfile.Id || m.ReceiverId == foundUserProfile.Id).ToList();
        _dbContext.Messages.RemoveRange(foundMessages);

        List<MessageConversation> foundMessageConversations = _dbContext.MessageConversations.Where(m => m.UserProfileId1 == foundUserProfile.Id || m.UserProfileId2 == foundUserProfile.Id).ToList();
        _dbContext.MessageConversations.RemoveRange(foundMessageConversations);

        _dbContext.UserProfiles.Remove(foundUserProfile);

        await _userManager.DeleteAsync(user);

        _dbContext.SaveChanges();


        return NoContent();
    }



}