using Microsoft.EntityFrameworkCore;
using UFCfights.Models;

namespace UFCfights.Data;

public class FightsContext : DbContext
{
    public FightsContext(DbContextOptions<FightsContext> options) : base(options) { }
    public DbSet<Fight> Fights => Set<Fight>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fight>()
            .HasIndex(f => new { f.R_fighter, f.B_fighter });
    }
}
