namespace HoldMyBeerServer.Dtos.Friends;

public enum FriendshipStatus{
    Pending,
    Accepted,
    Rejected
}

public record class FriendRequestDto
(
    string Id,
    string RequesterId,
    string AddresseeId,
    string RequesterUserName,
    string AddresseeUserName,
    FriendshipStatus Status
);