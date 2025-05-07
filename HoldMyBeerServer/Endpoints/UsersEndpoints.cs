using System;
using HoldMyBeerServer.Data;
using HoldMyBeerServer.Dtos;
using HoldMyBeerServer.Dtos.Friends;
using HoldMyBeerServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace HoldMyBeerServer.Endpoints;
public static class UsersEndpoints
{

const string GetUserEndpointName = "GetUser";



public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app){

var group = app.MapGroup("users").WithParameterValidation();
var id = Guid.NewGuid().ToString();

// GET - ALL USERS
group.MapGet("/", () => UserStore.users);

// GET - USER
group.MapGet("/{id}", (string id) => {

    UserDto? user = UserStore.users.Find(user => user.Id == id);

    return user is null ? Results.NotFound() : Results.Ok(user);
}
)
.WithName(GetUserEndpointName);

// POST - CREATE USER
group.MapPost("/",(CreateUserDto newUser,HoldMyBeerContext dbContext)=> {
    
    User user = new() {
        Id = id,
        UserName = newUser.UserName,
        Password = newUser.Password,
        Email = newUser.Email,
        CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow)
    };

    dbContext.Users.Add(user);
    dbContext.SaveChanges();

    return Results.CreatedAtRoute(GetUserEndpointName,
     new { id = user.Id }, user);
});

// PUT - UPDATE USER
group.MapPut("/{id}",(string id , UpdateUserDto updatedUser)=> {
 var userIndex = UserStore.users.FindIndex(user => user.Id == id);

if (userIndex == -1) {
    return Results.NotFound();
}

// var existingFriends = UserStore.users[userIndex].Friends;

 UserStore.users[userIndex] = new UserDto(
    id,
    updatedUser.UserName,
    updatedUser.Password,
    updatedUser.Email,
    UserStore.users[userIndex].CreatedDate
    // existingFriends
 );

 return Results.NoContent();
});

// DELETE - USER 
group.MapDelete("/{id}",(string id)=> {
    UserStore.users.RemoveAll(user => user.Id == id);

 return Results.NoContent();
  });


  return group;
 }
}
