using HoldMyBeerServer.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetUserEndpointName = "GetUser";

List<UserDto> users = [
    new (1,"miladUser","Pass123","milad@test.com",new DateOnly(2020,07,15)),
    new (2,"sadafUser","Pass456","sadaf@test.com",new DateOnly(2021,01,15)),
    new (3,"sagUser","Pass789","sag@test.com",new DateOnly(2022,09,15))
];


// GET - ALL USERS
app.MapGet("users", () => users);

// GET - USER
app.MapGet("users/{id}", (int id) => users.Find(user => user.Id == id))
.WithName(GetUserEndpointName);

// POST - CREATE USER
app.MapPost("users",(CreateUserDto newUser)=> {
    UserDto user = new (
        users.Count + 1,
        newUser.UserName,
        newUser.Password,
        newUser.Email,
        newUser.CreatedDate
    );
    users.Add(user);

    return Results.CreatedAtRoute(GetUserEndpointName,
     new { id = user.Id }, user);
});


app.Run();
