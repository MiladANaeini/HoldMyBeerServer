using System;

namespace HoldMyBeerServer.Endpoints.Friends;

public static class FriendRelationsEndpoint
{
  const string GetFriendsEndpointName = "GetFriends";
public static RouteGroupBuilder MapFriendRelationEndpoints(this WebApplication app){

var group = app.MapGroup("friends").WithParameterValidation();

// GET - USER FRIENDS 
// group.MapGet("/{id}", (string id) => {
   

// });
  return group;

 }
}
