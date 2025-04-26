using System.ComponentModel.DataAnnotations;

namespace HoldMyBeerServer.Dtos.Friends;

public record class CreateFriendRequestDto
(
    [Required] string RequesterId,
    [Required] string AddresseeId
);
