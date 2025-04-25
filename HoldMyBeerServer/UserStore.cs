using System;
using HoldMyBeerServer.Dtos;
using HoldMyBeerServer.Dtos.Friends;

namespace HoldMyBeerServer;

public static class UserStore
{
public static readonly List<UserDto> users = [
    new (1,"miladUser","Pass123","milad@test.com",
    new DateOnly(2020,07,15), new List<FriendDto>(),
    new List<FriendRequestDto>()),
    new (2,"sadafUser","Pass456","sadaf@test.com",
    new DateOnly(2021,01,15),new List<FriendDto>(),
    new List<FriendRequestDto>()),
    new (3,"sagUser","Pass789","sag@test.com",
    new DateOnly(2022,09,15), new List<FriendDto>
        {
            new(1, "miladUser")
        }, new List<FriendRequestDto>
        {
            new(111, 3 , 2,"sadafUser",FriendshipStatus.Pending)
        })
];
}
