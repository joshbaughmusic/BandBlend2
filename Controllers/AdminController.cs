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

    [HttpDelete("userprofile/{identityUserId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AdminDeleteUserAccount(string identityUserId)
    {
        var user = await _userManager.FindByIdAsync(identityUserId);

        UserProfile foundUserProfile = _dbContext.UserProfiles
        .Include(up => up.Profile)
        .SingleOrDefault(up => up.IdentityUserId == identityUserId);

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

    [HttpGet("banned")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdmimGetAllBannedAccounts()
    {

        List<UserProfile> foundBannedAccounts = _dbContext.UserProfiles
            .Include(up => up.Profile)
            .Where(up => up.AccountBanned)
            .ToList();

        return Ok(foundBannedAccounts);
    }

    [HttpPut("unban/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminUnbanAccount(int id)
    {
        UserProfile foundUserProfile = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == id);

        if (foundUserProfile == null)
        {
            return NotFound();
        }

        foundUserProfile.AccountBanned = false;

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPut("ban/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminBanAccount(int id)
    {
        UserProfile foundUserProfile = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == id);

        if (foundUserProfile == null)
        {
            return NotFound();
        }

        foundUserProfile.AccountBanned = true;

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("post/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminDeletePost(int id)
    {

        Post foundPost = _dbContext.Posts.SingleOrDefault(p => p.Id == id);

        if (foundPost != null)
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

        return NotFound();
    }


    [HttpDelete("comment/{id}")]
    [Authorize(Roles = "Admin")]

    public IActionResult AdminDeleteComment(int id)
    {
        Comment foundComment = _dbContext.Comments.SingleOrDefault(p => p.Id == id);

        if (foundComment != null)
        {
            List<CommentLike> foundCommentLikes = _dbContext.CommentLikes.Where(cl => cl.CommentId == foundComment.Id).ToList();
            _dbContext.CommentLikes.RemoveRange(foundCommentLikes);
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