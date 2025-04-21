namespace HoldMyBeerServer.Dtos.Friends;

public enum FriendshipStatus{
    Pending,
    Accepted,
    Rejected
}
public record class FriendsDto
(
    int Id,
    int RequesterId,
    int AddresseeId,
    FriendshipStatus Status
);