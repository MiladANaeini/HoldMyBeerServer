namespace HoldMyBeerServer.Dtos;

public record class CreateUserDto(
    string UserName, 
    string Password, 
    string Email,
    DateOnly CreatedDate
);
