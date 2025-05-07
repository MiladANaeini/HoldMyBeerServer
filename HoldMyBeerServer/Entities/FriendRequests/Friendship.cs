using System;

namespace HoldMyBeerServer.Entities.FriendRequests;

public class Friendship
{
    public string Id { get; set; } = Guid.NewGuid().ToString();    
    public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;

    public string FriendId { get; set; } = null!;
    public User Friend { get; set; } = null!;

    public DateOnly  CreatedAt { get; set; } 
}
