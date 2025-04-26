using System;
using HoldMyBeerServer.Dtos;
using HoldMyBeerServer.Dtos.Friends;

namespace HoldMyBeerServer.Endpoints;

public static class FriendRequestEndpoints
{
const string FriendRequestEndpointName = "CreateFriendRequest";
public static RouteGroupBuilder MapFriendRequestEndpoints(this WebApplication app){

var group = app.MapGroup("FriendRequests").WithParameterValidation();
 var reqList = UserStore.userRequests;

//  POST - CREATE USER
group.MapPost("/", (CreateFriendRequest newRequest) =>
{

 int requesterId = newRequest.RequesterId;
 int addresseeId = newRequest.AddresseeId;

 var requesterIndex = UserStore.users.FindIndex(user=> user.Id == requesterId);
 var addresseeIndex = UserStore.users.FindIndex(user=> user.Id == addresseeId);

 if (requesterIndex == -1 || addresseeIndex == -1)
    return Results.NotFound("User not found");

if (!reqList.TryGetValue(requesterId, out var user))
{
    user = new UserStore.UserRequests();
    reqList[requesterId] = user;
}

if (!reqList.TryGetValue(addresseeId, out var targetUser))
{
    targetUser = new UserStore.UserRequests();
    reqList[addresseeId] = targetUser;
}

 var newFriendRequest = new FriendRequestDto(
        Id: Guid.NewGuid().ToString(),
        RequesterId: requesterId,
        AddresseeId: addresseeId,
        RequesterUserName:UserStore.users[requesterIndex].UserName,
        AddresseeUserName:UserStore.users[addresseeIndex].UserName,
        Status: FriendshipStatus.Pending
    );
  user.SentRequests.Add(newFriendRequest);
  targetUser.ReceivedRequests.Add(newFriendRequest);


   return Results.Ok(newFriendRequest);

});

group.MapGet("/{id}/sent", (int id) =>{

  var userIndex = UserStore.users.FindIndex(user => user.Id == id);

   if (userIndex == -1)
    {
        return Results.NotFound();
    }

   var sentRequests = reqList.TryGetValue(id, out var userRequests)
        ? userRequests.SentRequests
        : new List<FriendRequestDto>();

    return Results.Ok(sentRequests);
});

group.MapGet("/{id}/received", (int id) =>{

  var userIndex = UserStore.users.FindIndex(user => user.Id == id);

   if (userIndex == -1)
    {
        return Results.NotFound();
    }

   var receivedRequests = reqList.TryGetValue(id, out var userRequests)
        ? userRequests.ReceivedRequests
        : new List<FriendRequestDto>();

    return Results.Ok(receivedRequests);
});



  return group;
 }
}
