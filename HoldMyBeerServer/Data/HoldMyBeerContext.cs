using System;
using HoldMyBeerServer.Entities;
using HoldMyBeerServer.Entities.FriendRequests;
using Microsoft.EntityFrameworkCore;

namespace HoldMyBeerServer.Data;

public class HoldMyBeerContext(DbContextOptions<HoldMyBeerContext> options)
 : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<FriendRequest> FriendRequests => Set<FriendRequest>();
    public DbSet<Friendship> Friendships => Set<Friendship>();

   protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
    // Configure FriendRequest: Requester
    modelBuilder.Entity<FriendRequest>()
        .HasOne(fr => fr.Requester)
        .WithMany(u => u.SentRequests)
        .HasForeignKey(fr => fr.RequesterId)
        .OnDelete(DeleteBehavior.NoAction);

    // Configure FriendRequest: Addressee
    modelBuilder.Entity<FriendRequest>()
        .HasOne(fr => fr.Addressee)
        .WithMany(u => u.ReceivedRequests)
        .HasForeignKey(fr => fr.AddresseeId)
        .OnDelete(DeleteBehavior.NoAction);

    // Configure Friendship: User and Friend
    modelBuilder.Entity<Friendship>()
        .HasKey(f => new { f.UserId, f.FriendId });  // Composite key

    modelBuilder.Entity<Friendship>()
        .HasOne(f => f.User)
        .WithMany(u => u.Friendships)
        .HasForeignKey(f => f.UserId)
        .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<Friendship>()
        .HasOne(f => f.Friend)
        .WithMany()
        .HasForeignKey(f => f.FriendId)
        .OnDelete(DeleteBehavior.Cascade);

    base.OnModelCreating(modelBuilder);
 }

}
