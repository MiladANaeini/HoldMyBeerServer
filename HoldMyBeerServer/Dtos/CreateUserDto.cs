using System.ComponentModel.DataAnnotations;

namespace HoldMyBeerServer.Dtos;

public record class CreateUserDto(
   [Required][StringLength(50)] string UserName, 
   [Required][StringLength(50)] string Password, 
   [Required][EmailAddress][StringLength(50)]string Email,
    DateOnly CreatedDate
);
