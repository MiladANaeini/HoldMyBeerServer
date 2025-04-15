namespace HoldMyBeerServer.Dtos;

public record class UpdateUserDto(
    string UserName, 
    string Password, 
    string Email
);
