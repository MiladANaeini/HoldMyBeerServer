using System;
using HoldMyBeerServer.Dtos;
using HoldMyBeerServer.Dtos.Friends;

namespace HoldMyBeerServer.Endpoints;

public static class FriendRequestEndpoints
{
const string FriendRequestEndpointName = "CreateFriendRequest";
private static readonly List<UserDto> users = [
    new (1,"miladUser","Pass123","milad@test.com",
    new DateOnly(2020,07,15), new List<FriendDto>(),
    new List<FriendRequestDto>()),
    new (2,"sadafUser","Pass456","sadaf@test.com",
    new DateOnly(2021,01,15),new List<FriendDto>(),
    new List<FriendRequestDto>()),
    new (3,"sagUser","Pass789","sag@test.com",
    new DateOnly(2022,09,15), new List<FriendDto>
        {
            new(2, "sadafUser"),
            new(1, "miladUser")
        }, new List<FriendRequestDto>
        {
            new(111, 3 , 2,FriendshipStatus.Pending)
        })
];
public static RouteGroupBuilder MapFriendRequestEndpoints(this WebApplication app){

var group = app.MapGroup("FriendRequests").WithParameterValidation();

//  POST - CREATE USER
group.MapPost("/", (CreateFriendRequest newRequest) =>
{

 int requesterId = newRequest.RequesterId;
 int addresseeId = newRequest.AddresseeId;

 var requesterIndex = users.FindIndex(user=> user.Id == requesterId);
 var addresseeIndex = users.FindIndex(user=> user.Id == addresseeId);

 if (requesterIndex == -1 || addresseeIndex == -1)
    return Results.NotFound("User not found");

var user = users[requesterIndex];

 var newFriendRequest = new FriendRequestDto(
        Id: users.Count + 10000000,
        RequesterId: requesterId,
        AddresseeId: addresseeId,
        Status: FriendshipStatus.Pending
    );
   user.Requests.Add(newFriendRequest);

   return Results.Ok(newFriendRequest);

});
  return group;
 }
}
