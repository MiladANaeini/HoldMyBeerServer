using System;
using HoldMyBeerServer.Dtos;

namespace HoldMyBeerServer.Endpoints;
public static class UsersEndpoints
{

const string GetUserEndpointName = "GetUser";

private static readonly List<UserDto> users = [
    new (1,"miladUser","Pass123","milad@test.com",new DateOnly(2020,07,15)),
    new (2,"sadafUser","Pass456","sadaf@test.com",new DateOnly(2021,01,15)),
    new (3,"sagUser","Pass789","sag@test.com",new DateOnly(2022,09,15))
];

public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app){

var group = app.MapGroup("users").WithParameterValidation();


// GET - ALL USERS
group.MapGet("/", () => users);

// GET - USER
group.MapGet("/{id}", (int id) => {

    UserDto? user = users.Find(user => user.Id == id);

    return user is null ? Results.NotFound() : Results.Ok(user);
}
)
.WithName(GetUserEndpointName);

// POST - CREATE USER
group.MapPost("/",(CreateUserDto newUser)=> {
    UserDto user = new (
        users.Count + 1,
        newUser.UserName,
        newUser.Password,
        newUser.Email,
        newUser.CreatedDate
    );
    users.Add(user);

    return Results.CreatedAtRoute(GetUserEndpointName,
     new { id = user.Id }, user);
});

// PUT - UPDATE USER
group.MapPut("/{id}",(int id , UpdateUserDto updatedUser)=> {
 var userIndex = users.FindIndex(user => user.Id == id);

if (userIndex == -1) {
    return Results.NotFound();
}

 users[userIndex] = new UserDto(
    id,
    updatedUser.UserName,
    updatedUser.Password,
    updatedUser.Email,
    users[userIndex].CreatedDate
 );

 return Results.NoContent();
});

// DELETE - USER 
group.MapDelete("/{id}",(int id)=> {
    users.RemoveAll(user => user.Id == id);

 return Results.NoContent();
  });


  return group;
 }
}
