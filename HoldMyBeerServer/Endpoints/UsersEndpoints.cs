using System;
using HoldMyBeerServer.Dtos;
using HoldMyBeerServer.Dtos.Friends;

namespace HoldMyBeerServer.Endpoints;
public static class UsersEndpoints
{

const string GetUserEndpointName = "GetUser";



public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app){

var group = app.MapGroup("users").WithParameterValidation();


// GET - ALL USERS
group.MapGet("/", () => UserStore.users);

// GET - USER
group.MapGet("/{id}", (int id) => {

    UserDto? user = UserStore.users.Find(user => user.Id == id);

    return user is null ? Results.NotFound() : Results.Ok(user);
}
)
.WithName(GetUserEndpointName);

// POST - CREATE USER
group.MapPost("/",(CreateUserDto newUser)=> {
    UserDto user = new (
        UserStore.users.Count + 1,
        newUser.UserName,
        newUser.Password,
        newUser.Email,
        newUser.CreatedDate,
        new List<FriendDto>(),
        new List<FriendRequestDto>()
    );
    UserStore.users.Add(user);

    return Results.CreatedAtRoute(GetUserEndpointName,
     new { id = user.Id }, user);
});

// PUT - UPDATE USER
group.MapPut("/{id}",(int id , UpdateUserDto updatedUser)=> {
 var userIndex = UserStore.users.FindIndex(user => user.Id == id);

if (userIndex == -1) {
    return Results.NotFound();
}

var existingFriends = UserStore.users[userIndex].Friends;
var requestedFriends = UserStore.users[userIndex].Requests;

 UserStore.users[userIndex] = new UserDto(
    id,
    updatedUser.UserName,
    updatedUser.Password,
    updatedUser.Email,
    UserStore.users[userIndex].CreatedDate,
    existingFriends,
    requestedFriends
 );

 return Results.NoContent();
});

// DELETE - USER 
group.MapDelete("/{id}",(int id)=> {
    UserStore.users.RemoveAll(user => user.Id == id);

 return Results.NoContent();
  });


  return group;
 }
}
