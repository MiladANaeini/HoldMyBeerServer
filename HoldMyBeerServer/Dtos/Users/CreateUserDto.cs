using System.ComponentModel.DataAnnotations;
using HoldMyBeerServer.Dtos.Friends;

namespace HoldMyBeerServer.Dtos;

public record class CreateUserDto(
   [Required][StringLength(50)] string UserName, 
   [Required][StringLength(50)] string Password, 
   [Required][EmailAddress][StringLength(50)]string Email,
    DateOnly CreatedDate
);
