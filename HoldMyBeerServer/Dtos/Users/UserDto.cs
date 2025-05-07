using HoldMyBeerServer.Dtos.Friends;

namespace HoldMyBeerServer.Dtos;

public record class UserDto(
    string Id,
    string UserName, 
    string Password, 
    string Email,
    DateOnly CreatedDate
    );
