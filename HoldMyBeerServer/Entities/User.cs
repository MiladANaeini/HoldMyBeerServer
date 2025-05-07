using System;
using HoldMyBeerServer.Entities.FriendRequests;

namespace HoldMyBeerServer.Entities;

public class User
{
   public string Id { get; set; } = null!;

   public string UserName { get; set; } = null!;
   public string Password { get; set; } = null!;
   public string Email { get; set; } = null!;
   public DateOnly CreatedDate { get; set; }
   
   public List<FriendRequest> ReceivedRequests  { get; set; } = new();
   public List<FriendRequest> SentRequests  { get; set; } = new();
   public List<Friendship> Friendships  { get; set; } = new();
}
