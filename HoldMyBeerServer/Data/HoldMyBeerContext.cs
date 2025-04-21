using System;
using HoldMyBeerServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace HoldMyBeerServer.Data;

public class HoldMyBeerContext(DbContextOptions<HoldMyBeerContext> options)
 : DbContext(options)
{
   public DbSet<User> Users => Set<User>();
}
