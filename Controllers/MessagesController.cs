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
public class MessagesController : ControllerBase
{
    private BandBlendDbContext _dbContext;


    public MessagesController(BandBlendDbContext context)
    {
        _dbContext = context;

    }

    [HttpGet("conversations")]
    [Authorize]
    public IActionResult GetExistingConversations()
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<MessageConversation> foundMessageConversations = _dbContext.MessageConversations
        .Include(mc => mc.UserProfile1)
        .ThenInclude(up => up.Profile)
        .Include(mc => mc.UserProfile2)
        .ThenInclude(up => up.Profile)
        .Where(mc => mc.UserProfileIdIdentityUserId1 == loggedInUser.IdentityUserId || mc.UserProfileIdIdentityUserId2 == loggedInUser.IdentityUserId)
        .OrderByDescending(mc => mc.LastMessageDate)
        .ToList();

        return Ok(foundMessageConversations);

    }

    [HttpGet("messages/{conversationId}")]
    [Authorize]
    public IActionResult GetExistingMessages(int conversationId)
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        MessageConversation foundMessageConversation = _dbContext.MessageConversations.SingleOrDefault(mc => mc.Id == conversationId && (mc.UserProfileIdIdentityUserId1 == loggedInUser.IdentityUserId || mc.UserProfileIdIdentityUserId2 == loggedInUser.IdentityUserId));

        if (foundMessageConversation == null)
        {
            return NotFound();
        }

        List<Message> foundMessages = _dbContext.Messages
        .Include(m => m.Sender)
        .ThenInclude(up => up.Profile)
        .Include(m => m.Receiver)
        .ThenInclude(up => up.Profile)
        .Where(m => m.MessageConversationId == conversationId && (m.SenderIdentityUserId == loggedInUser.IdentityUserId || m.ReceiverIdentityUserId == loggedInUser.IdentityUserId))
        .OrderBy(m => m.Date)
        .ToList();

        return Ok(foundMessages);
    }
}
