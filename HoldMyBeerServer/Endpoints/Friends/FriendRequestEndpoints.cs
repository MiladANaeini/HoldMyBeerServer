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

// //  POST - CREATE USER
// group.MapPost("/", (CreateFriendRequestDto newRequest) =>
// {

//  string requesterId = newRequest.RequesterId;
//  string addresseeId = newRequest.AddresseeId;

//  var requesterIndex = UserStore.users.FindIndex(user=> user.Id == requesterId);
//  var addresseeIndex = UserStore.users.FindIndex(user=> user.Id == addresseeId);

//  if (requesterIndex == -1 || addresseeIndex == -1)
//     return Results.NotFound("User not found");

// if (!reqList.TryGetValue(requesterId, out var user))
// {
//     user = new UserStore.UserRequests();
//     reqList[requesterId] = user;
// }

// if (!reqList.TryGetValue(addresseeId, out var targetUser))
// {
//     targetUser = new UserStore.UserRequests();
//     reqList[addresseeId] = targetUser;
// }

//  var newFriendRequest = new FriendRequestDto(
//         Id: Guid.NewGuid().ToString(),
//         RequesterId: requesterId,
//         AddresseeId: addresseeId,
//         RequesterUserName:UserStore.users[requesterIndex].UserName,
//         AddresseeUserName:UserStore.users[addresseeIndex].UserName,
//         Status: FriendshipStatus.Pending
//     );
//   user.SentRequests.Add(newFriendRequest);
//   targetUser.ReceivedRequests.Add(newFriendRequest);


//    return Results.Ok(newFriendRequest);

// });

// PUT - CHANGE REQEUST STATUS
// group.MapPut("/{requestId}",(string requestId,FriendRequestDto updateRequest) => {
 
//  //Check if the user exists
//  var userId = updateRequest.AddresseeId;
//  var userIndex = UserStore.users.FindIndex(user=> user.Id == userId);
//  if (userIndex == -1)
//     return Results.NotFound("User not found");

//  var targetUserId = updateRequest.RequesterId;
//  var targetUserIndex = UserStore.users.FindIndex(user=> user.Id == targetUserId);
//  if (targetUserIndex == -1)
//     return Results.NotFound("targetUser not found");


//  if (!reqList.TryGetValue(userId, out var user))
// {
//     return Results.NotFound("Request does not exist");
// }

//  if (!reqList.TryGetValue(targetUserId, out var targetUser))
// {
//     return Results.NotFound("Request does not exist");
// }


// var friendRequest = user.ReceivedRequests.FirstOrDefault(req => req.Id == requestId);
// if (friendRequest == null)
//     {
//         return Results.NotFound("Friend request not found");
//     }

//  var updatedRequest = friendRequest with { Status = updateRequest.Status };

//    if(updateRequest.Status == FriendshipStatus.Accepted){
//      UserStore.users[userIndex].Friends.Add(new FriendDto(
//             friendRequest.RequesterId,
//             friendRequest.RequesterUserName
//         ));
        
//         UserStore.users[targetUserIndex].Friends.Add(new FriendDto(
//             friendRequest.AddresseeId,
//             friendRequest.AddresseeUserName
//         ));
//    }
//    // delete the request from requestlist of user and targetuser
//     user.ReceivedRequests.RemoveAll(r => r.Id == requestId);
//     targetUser.SentRequests.RemoveAll(r => r.Id == requestId);

//     return Results.Ok(updatedRequest);

// });


// GET - USER SENT REQUESTS
group.MapGet("/{id}/sent", (string id) =>{

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

// GET - USER RECEIVED REQUESTS
group.MapGet("/{id}/received", (string id) =>{

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
