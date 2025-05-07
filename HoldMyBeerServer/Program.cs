using HoldMyBeerServer.Endpoints;
using HoldMyBeerServer.Data;
using HoldMyBeerServer.Endpoints.Friends;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("HoldMyBeer");
builder.Services.AddSqlite<HoldMyBeerContext>(connString);

var app = builder.Build();



app.MapUsersEndpoints();
app.MapFriendRelationEndpoints();
app.MapFriendRequestEndpoints();

app.MigrateDb();

app.Run();
