using System;

namespace HoldMyBeerServer.Entities;

public class Friend
{
    public string Id { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string UserId { get; set; } = null!;// FK to the User
    public User User { get; set; } = null!;
}
