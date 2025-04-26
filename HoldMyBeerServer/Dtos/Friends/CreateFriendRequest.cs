using System.ComponentModel.DataAnnotations;

namespace HoldMyBeerServer.Dtos.Friends;

public record class CreateFriendRequest
(
    [Required] string RequesterId,
    [Required] string AddresseeId
);
