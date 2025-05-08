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
group.MapGet("/", async (HoldMyBeerContext dbContext) => {

    var users = await dbContext.Users.ToListAsync();

    if(users == null || users.Count == 0){
        return Results.NoContent(); // 204 no users exist
    }

    return Results.Ok(users); // 200
});

// GET - USER
group.MapGet("/{id}", (string id , HoldMyBeerContext dbContext) => {

   var user = dbContext.Users.Find(id);
   return user is null ? Results.NotFound() : Results.Ok(user)
;   
}
)
.WithName(GetUserEndpointName);

// POST - CREATE USER
group.MapPost("/",(CreateUserDto newUser,HoldMyBeerContext dbContext)=> {

    var exsitingUserEmail = dbContext.Users.FirstOrDefault(u => u.Email == newUser.Email);

    if(exsitingUserEmail != null){
        return Results.BadRequest("Email already in use");
    }
    
    var exsitingUserName = dbContext.Users.FirstOrDefault(u => u.UserName == newUser.UserName);

    if(exsitingUserName != null){
        return Results.BadRequest("UserName is already taken");
    }
    
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
group.MapPut("/{id}",(string id, UpdateUserDto updatedUser, HoldMyBeerContext dbContext)=> {

 var existingUser = dbContext.Users.FirstOrDefault(u => u.Id == id);    

if (existingUser == null) {
     return Results.BadRequest("User Not found");
}

 // Check for uniqueness of email and username (excluding the current user)
    bool emailInUse = dbContext.Users.Any(u => u.Email == updatedUser.Email && u.Id != id);
    bool usernameInUse = dbContext.Users.Any(u => u.UserName == updatedUser.UserName && u.Id != id);
    if (emailInUse || usernameInUse)
    {
        return Results.BadRequest("Email or username already in use by another user.");
    }

    // Update the user
    existingUser.UserName = updatedUser.UserName;
    existingUser.Password = updatedUser.Password;
    existingUser.Email = updatedUser.Email;

    dbContext.SaveChanges();

    return Results.NoContent();
});

// DELETE - USER 
group.MapDelete("/{id}", (string id, HoldMyBeerContext dbContext) =>
{
    var user = dbContext.Users.FirstOrDefault(u => u.Id == id);
    if (user == null)
    {
        return Results.NotFound("User not found.");
    }

    dbContext.Users.Remove(user);
    dbContext.SaveChanges();

    return Results.NoContent();
});


  return group;
 }
}
