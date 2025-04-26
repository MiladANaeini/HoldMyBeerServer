namespace HoldMyBeerServer.Dtos.Friends;

public enum FriendshipStatus{
    Pending,
    Accepted,
    Rejected
}

public record class FriendRequestDto
(
    int Id,
    int RequesterId,
    int AddresseeId,
    string RequesterUserName,
    string AddresseeUserName,
    FriendshipStatus Status
);