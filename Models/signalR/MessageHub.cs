using BandBlend.Data;
using BandBlend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
namespace BandBlend.Hubs;
using System.Linq;


public class MessageHub : Hub
{
    private BandBlendDbContext _dbContext;

    public MessageHub(BandBlendDbContext context)
    {
        _dbContext = context;
    }

    public async Task SendMessage(Message message)
    {
        UserProfile senderUserProfile = _dbContext.UserProfiles
        .SingleOrDefault(up => up.IdentityUserId == message.SenderIdentityUserId);
        UserProfile recipientUserProfile = _dbContext.UserProfiles.
        SingleOrDefault(up => up.IdentityUserId == message.ReceiverIdentityUserId);

        // senderUserProfile.Profile = _dbContext.Profiles.Single(p => p.UserProfileId == senderUserProfile.Id);

        // recipientUserProfile.Profile = _dbContext.Profiles.Single(p => p.UserProfileId == recipientUserProfile.Id);

        if (senderUserProfile == null || recipientUserProfile == null)
        {
            return;
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
        await _dbContext.SaveChangesAsync();

        await Clients.User(senderUserProfile.IdentityUserId).SendAsync("SendMessage", newMessage);
    }

}