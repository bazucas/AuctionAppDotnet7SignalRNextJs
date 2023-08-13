using AuctionService.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public class AuctionDbContext : DbContext
{
    public AuctionDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Auction> Auctions { get; set; }
    // public DbSet<Item> Items { get; set; } // not needed already defined Items table on entity, and Auction already have a Item inside

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // add MassTransit needed tables/entities for outbox messaging
        base.OnModelCreating(modelBuilder);
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
    }
}
