using System;

namespace HoldMyBeerServer.Entities;

public class User
{
   public int Id { get; set; }

   public string UserName { get; set; } = null!;
   public string Password { get; set; } = null!;
   public string Email { get; set; } = null!;
   public DateTime CreatedDate { get; set; }
   
    public List<Friend> Friends { get; set; } = new();
}
