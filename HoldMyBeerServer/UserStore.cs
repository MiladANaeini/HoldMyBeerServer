using System;
using HoldMyBeerServer.Dtos;
using HoldMyBeerServer.Dtos.Friends;

namespace HoldMyBeerServer;

public static class UserStore
{
public static readonly List<UserDto> users = [
    new ("1","miladUser","Pass123","milad@test.com",
    new DateOnly(2020,07,15)),
    new ("2","sadafUser","Pass456","sadaf@test.com",
    new DateOnly(2021,01,15)),
    new ("3","sagUser","Pass789","sag@test.com",
    new DateOnly(2022,09,15))
  ];

    public static readonly Dictionary<string, UserRequests> userRequests = new()
    {
        { "1", new UserRequests
            {
                ReceivedRequests = new List<FriendRequestDto>
                {
                    new FriendRequestDto("10001", "3", "1", "sagUser", "miladUser", FriendshipStatus.Pending,new DateOnly(2022,09,15))
                },
                SentRequests = new List<FriendRequestDto>
                {
                    new FriendRequestDto("10002", "1", "2", "miladUser", "sadafUser", FriendshipStatus.Pending,new DateOnly(2022,09,15))
                }
            }
        }
    };

    public class UserRequests
  {
    public List<FriendRequestDto> ReceivedRequests { get; set; } = new();
    public List<FriendRequestDto> SentRequests { get; set; } = new();
  }
}
