using BandBlend.Models;
using Microsoft.AspNetCore.SignalR;
namespace BandBlend.Hubs;

public class UserConnection
{
    public string User {get; set;}
    public string Room {get; set;}
}