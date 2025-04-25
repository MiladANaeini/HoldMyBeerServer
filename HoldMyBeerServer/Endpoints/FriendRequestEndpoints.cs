using System;
using HoldMyBeerServer.Dtos;
using HoldMyBeerServer.Dtos.Friends;

namespace HoldMyBeerServer.Endpoints;

public static class FriendRequestEndpoints
{
const string FriendRequestEndpointName = "CreateFriendRequest";

public static RouteGroupBuilder MapFriendRequestEndpoints(this WebApplication app){

var group = app.MapGroup("FriendRequests").WithParameterValidation();

//  POST - CREATE USER
group.MapPost("/", (CreateFriendRequest newRequest) =>
{

 int requesterId = newRequest.RequesterId;
 int addresseeId = newRequest.AddresseeId;

 var requesterIndex = UserStore.users.FindIndex(user=> user.Id == requesterId);
 var addresseeIndex = UserStore.users.FindIndex(user=> user.Id == addresseeId);

 if (requesterIndex == -1 || addresseeIndex == -1)
    return Results.NotFound("User not found");

var user = UserStore.users[requesterIndex];

 var newFriendRequest = new FriendRequestDto(
        Id: UserStore.users.Count + 10000000,
        RequesterId: requesterId,
        AddresseeId: addresseeId,
        AddresseeUserName:UserStore.users[addresseeIndex].UserName,
        Status: FriendshipStatus.Pending
    );
   user.Requests.Add(newFriendRequest);



   return Results.Ok(newFriendRequest);

});
  return group;
 }
}
