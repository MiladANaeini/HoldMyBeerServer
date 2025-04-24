using System.ComponentModel.DataAnnotations;

namespace HoldMyBeerServer.Dtos.Friends;

public record class CreateFriendRequest
(
    [Required] int RequesterId,
    [Required] int AddresseeId
);
