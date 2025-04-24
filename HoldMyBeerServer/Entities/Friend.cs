using System;

namespace HoldMyBeerServer.Entities;

public class Friend
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public int UserId { get; set; } // FK to the User
    public User User { get; set; } = null!;
}
