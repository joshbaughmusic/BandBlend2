using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BandBlend.Data;
using Microsoft.EntityFrameworkCore;
using BandBlend.Models;
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

        List<BlockedAccount> userBlockedAccounts = _dbContext.BlockedAccounts.Where(ba => ba.UserProfileThatBlockedId == loggedInUser.Id).ToList();

        List<BlockedAccount> userBlockedByAccounts = _dbContext.BlockedAccounts.Where(ba => ba.BlockedUserProfileId == loggedInUser.Id).ToList();

        var blockedUserProfileIds = userBlockedAccounts.Select(ba => ba.BlockedUserProfileId).ToList();

        var blockedByUserProfileIds = userBlockedByAccounts.Select(ba => ba.UserProfileThatBlockedId).ToList();

        List<MessageConversation> foundMessageConversations = _dbContext.MessageConversations
        .Include(mc => mc.UserProfile1)
        .ThenInclude(up => up.Profile)
        .Include(mc => mc.UserProfile2)
        .ThenInclude(up => up.Profile)
        .Where(mc => mc.UserProfileIdIdentityUserId1 == loggedInUser.IdentityUserId || mc.UserProfileIdIdentityUserId2 == loggedInUser.IdentityUserId)
        .Where(mc => !blockedUserProfileIds.Contains(mc.UserProfileId1) && !blockedUserProfileIds.Contains(mc.UserProfileId2) &&
        !blockedByUserProfileIds.Contains(mc.UserProfileId1) && !blockedByUserProfileIds.Contains(mc.UserProfileId2))
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

    [HttpPost("existing")]
    [Authorize]
    public IActionResult SendNewMessageExistingConversation(Message message)
    {
        UserProfile senderUserProfile = _dbContext.UserProfiles
        .Include(up => up.Profile)
        .SingleOrDefault(up => up.IdentityUserId == message.SenderIdentityUserId);
        UserProfile recipientUserProfile = _dbContext.UserProfiles
        .Include(up => up.Profile)
        .SingleOrDefault(up => up.IdentityUserId == message.ReceiverIdentityUserId);

        if (senderUserProfile == null || recipientUserProfile == null)
        {
            return BadRequest();
        }

        var conversation = _dbContext.MessageConversations
                .FirstOrDefault(mc =>
                    (mc.UserProfileId1 == senderUserProfile.Id && mc.UserProfileId2 == recipientUserProfile.Id) ||
                    (mc.UserProfileId1 == recipientUserProfile.Id && mc.UserProfileId2 == senderUserProfile.Id));

        if (conversation == null)
        {
            conversation = new MessageConversation
            {
                UserProfileId1 = senderUserProfile.Id,
                UserProfileId2 = recipientUserProfile.Id,
                LastMessageDate = DateTime.Now
            };

            _dbContext.MessageConversations.Add(conversation);
        }
        else
        {
            conversation.LastMessageDate = DateTime.Now;
        }

        Message newMessage = new Message
        {
            SenderId = senderUserProfile.Id,
            ReceiverId = recipientUserProfile.Id,
            SenderIdentityUserId = senderUserProfile.IdentityUserId,
            ReceiverIdentityUserId = recipientUserProfile.IdentityUserId,
            Body = message.Body,
            Date = DateTime.Now,
            IsRead = false,
            MessageConversationId = conversation.Id,
            Sender = senderUserProfile,
            Receiver = recipientUserProfile
        };
        _dbContext.Messages.Add(newMessage);
        _dbContext.SaveChanges();

        return Ok();
    }
    
    [HttpPost("new")]
    [Authorize]
    public IActionResult SendNewMessageNoConversation(Message message)
    {
        UserProfile senderUserProfile = _dbContext.UserProfiles
        .Include(up => up.Profile)
        .SingleOrDefault(up => up.IdentityUserId == message.SenderIdentityUserId);
        UserProfile recipientUserProfile = _dbContext.UserProfiles
        .Include(up => up.Profile)
        .SingleOrDefault(up => up.IdentityUserId == message.ReceiverIdentityUserId);

        if (senderUserProfile == null || recipientUserProfile == null)
        {
            return BadRequest();
        }

        var conversation = _dbContext.MessageConversations
                .FirstOrDefault(mc =>
                    (mc.UserProfileId1 == senderUserProfile.Id && mc.UserProfileId2 == recipientUserProfile.Id) ||
                    (mc.UserProfileId1 == recipientUserProfile.Id && mc.UserProfileId2 == senderUserProfile.Id));

        if (conversation == null)
        {
            conversation = new MessageConversation
            {
                UserProfileId1 = senderUserProfile.Id,
                UserProfileIdIdentityUserId1 = message.SenderIdentityUserId,
                UserProfileId2 = recipientUserProfile.Id,
                UserProfileIdIdentityUserId2 = message.ReceiverIdentityUserId,
                LastMessageDate = DateTime.Now
            };

            _dbContext.MessageConversations.Add(conversation);
            _dbContext.SaveChanges();
        }
        else
        {
            conversation.LastMessageDate = DateTime.Now;
        }

        Message newMessage = new Message
        {
            SenderId = senderUserProfile.Id,
            ReceiverId = recipientUserProfile.Id,
            SenderIdentityUserId = senderUserProfile.IdentityUserId,
            ReceiverIdentityUserId = recipientUserProfile.IdentityUserId,
            Body = message.Body,
            Date = DateTime.Now,
            IsRead = false,
            MessageConversationId = conversation.Id,
            Sender = senderUserProfile,
            Receiver = recipientUserProfile
        };
        _dbContext.Messages.Add(newMessage);
        _dbContext.SaveChanges();

        return Created($"/api/messages/new/{newMessage.Id}", newMessage);
    }

    [HttpDelete("delete/{id}")]
    [Authorize]
    public IActionResult DeleteMessage(int id)
    {
        var loggedInUser = _dbContext
             .UserProfiles
             .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        Message foundMessage = _dbContext.Messages
        .SingleOrDefault(m => m.Id == id);


        if (foundMessage == null)
        {
            return NotFound();
        }

        if (foundMessage.SenderIdentityUserId != loggedInUser.IdentityUserId)
        {
            return BadRequest();
        }

        MessageConversation foundMessageConversation = _dbContext.MessageConversations
        .SingleOrDefault(mc => mc.Id == foundMessage.MessageConversationId);

        if (foundMessageConversation == null)
        {
            return NotFound();
        }

        List<Message> messagesInConversation = _dbContext.Messages
        .Where(m => m.MessageConversationId == foundMessageConversation.Id)
        .ToList();

        if(messagesInConversation.Count == 1)
        {
        _dbContext.Messages.Remove(foundMessage);
        _dbContext.MessageConversations.Remove(foundMessageConversation);
        _dbContext.SaveChanges();
        Response.Headers.Add("Result", "Deleted conversation");
        return NoContent();
        }
        else
        {
        _dbContext.Messages.Remove(foundMessage);
        _dbContext.SaveChanges();
        Response.Headers.Add("Result", "Did not delete conversation");
        return NoContent();
        }

    }

    [HttpDelete("delete/conversation/{id}")]
    [Authorize]
    public IActionResult DeleteMessageConversation(int id)
    {
        var loggedInUser = _dbContext
             .UserProfiles
             .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        UserProfile foundUserProfile = _dbContext.UserProfiles
        .SingleOrDefault(up => up.Id == loggedInUser.Id);

        MessageConversation foundMessageConversation = _dbContext.MessageConversations
        .SingleOrDefault(mc => mc.Id == id);

        if (foundMessageConversation == null)
        {
            return NotFound();
        }

        if (foundMessageConversation.UserProfileIdIdentityUserId1 != loggedInUser.IdentityUserId && foundMessageConversation.UserProfileIdIdentityUserId2 != loggedInUser.IdentityUserId)
        {
            return BadRequest();
        }


        List<Message> messagesInConversation = _dbContext.Messages
        .Where(m => m.MessageConversationId == foundMessageConversation.Id)
        .ToList();

       
        _dbContext.Messages.RemoveRange(messagesInConversation);
        _dbContext.MessageConversations.Remove(foundMessageConversation);
        _dbContext.SaveChanges();
      
        return NoContent();
  
    }

    [HttpPut("edit/{id}")]
    [Authorize]
    public IActionResult EditMessage(int id, [FromBody] string editedMessageBody)
    {
        Message foundMessage = _dbContext.Messages.SingleOrDefault(p => p.Id == id);
        if (foundMessage != null)
        {
            var loggedInUser = _dbContext
                .UserProfiles
                .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (loggedInUser.Id == foundMessage.SenderId)
            {
                foundMessage.Body = editedMessageBody;
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
