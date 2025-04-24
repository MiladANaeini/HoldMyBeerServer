using System;
using Microsoft.EntityFrameworkCore;

namespace HoldMyBeerServer.Data;

public static class DataExtensions
{
   public static void MigrateDb(this WebApplication app)
   // we run the migration each time we run the app from program.cs we run MigrateDb
   {
     using var scope = app.Services.CreateScope();
     var dbContext = scope.ServiceProvider.GetRequiredService<HoldMyBeerContext>();
     dbContext.Database.Migrate();
   }
}
