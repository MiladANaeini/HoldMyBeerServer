namespace HoldMyBeerServer.Dtos;

public record class UserDto(
    int Id,
    string UserName, 
    string Password, 
    string Email,
    DateOnly CreatedOn
    );
