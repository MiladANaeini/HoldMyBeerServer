using System;
using HoldMyBeerServer.Dtos.Friends;

namespace HoldMyBeerServer.Entities;

public class FriendRequest
{
   public int Id { get; set; }
    public int RequesterId { get; set; }
    public int AddresseeId { get; set; }
    public FriendshipStatus Status { get; set; }
    
    public User Requester { get; set; } = null!;
    public User Addressee { get; set; } = null!;
}
