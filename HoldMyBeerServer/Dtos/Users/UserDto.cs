using HoldMyBeerServer.Dtos.Friends;

namespace HoldMyBeerServer.Dtos;

public record class UserDto(
    int Id,
    string UserName, 
    string Password, 
    string Email,
    DateOnly CreatedDate,
    List<FriendDto> Friends,
    List<FriendRequestDto> Requests
    );
