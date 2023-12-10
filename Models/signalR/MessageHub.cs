using BandBlend.Data;
using BandBlend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
namespace BandBlend.Hubs;

using System.Collections.Concurrent;
using System.Linq;
using System.Security.Claims;

public class MessageHub : Hub
{
    private BandBlendDbContext _dbContext;
    private static readonly ConcurrentDictionary<string, string> userConnectionMap = new ConcurrentDictionary<string, string>();


    public MessageHub(BandBlendDbContext context)
    {
        _dbContext = context;
    }

    public override async Task OnConnectedAsync()
    {
        var userId = Context.GetHttpContext().Request.Query["userId"];
        // Store the connection ID for the user
        userConnectionMap.TryAdd(userId, Context.ConnectionId);
        await base.OnConnectedAsync();
    }
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        var connectionId = Context.ConnectionId;
        var userIdToRemove = userConnectionMap.FirstOrDefault(x => x.Value == connectionId).Key;
        if (userIdToRemove != null)
        {
            userConnectionMap.TryRemove(userIdToRemove, out _);
        }
        await base.OnDisconnectedAsync(exception);
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

        userConnectionMap.TryGetValue(senderUserProfile.IdentityUserId, out var senderConnectionId);
        userConnectionMap.TryGetValue(recipientUserProfile.IdentityUserId, out var recipientConnectionId);

        string currentUserConnectionId = Context.ConnectionId;

        await Clients.User(senderConnectionId).SendAsync("SendMessage", newMessage);
        await Clients.User(recipientConnectionId).SendAsync("SendMessage", newMessage);
    }

}