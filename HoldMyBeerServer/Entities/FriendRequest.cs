using System;
using HoldMyBeerServer.Dtos.Friends;

namespace HoldMyBeerServer.Entities;

public class FriendRequest
{
   public string Id { get; set; } = null!;
    public string RequesterId { get; set; } = null!;
    public string AddresseeId { get; set; } = null!;
    public FriendshipStatus Status { get; set; }
    
    public User Requester { get; set; } = null!;
    public User Addressee { get; set; } = null!;
}
