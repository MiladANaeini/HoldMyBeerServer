using HoldMyBeerServer.Endpoints;
using HoldMyBeerServer.Data;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("HoldMyBeer");
builder.Services.AddSqlite<HoldMyBeerContext>(connString);

var app = builder.Build();



app.MapGamesEndpoints();

app.MigrateDb();

app.Run();
