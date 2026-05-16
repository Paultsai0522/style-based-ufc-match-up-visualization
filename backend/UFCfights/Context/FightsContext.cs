using Microsoft.EntityFrameworkCore;
using UFCfights.Models;

namespace UFCfights.Data;

public class FightsContext : DbContext
{
    public FightsContext(DbContextOptions<FightsContext> options) : base(options) { }
    public DbSet<Fight> Fights => Set<Fight>();
    public DbSet<FighterStats> FighterStats => Set<FighterStats>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fight>()
            .HasIndex(f => new { f.R_Fighter, f.B_Fighter });

        modelBuilder.Entity<FighterStats>()
            .ToTable("FighterStats");
    }
}
