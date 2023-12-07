using BandBlend.Models;
using Microsoft.AspNetCore.SignalR;
namespace BandBlend.Hubs;

public class MessageHub : Hub
{
    private readonly string _botUser;

    public MessageHub()
    {
        _botUser = "MyChat Bot";
    }

    public async Task JoinRoom(UserConnection userConnection) 
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);
        await Clients.Group(userConnection.Room).SendAsync("ReceiveMessage", _botUser, $"{userConnection.User} has joined {userConnection.Room}");
    }

}