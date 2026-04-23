using Microsoft.EntityFrameworkCore;
using UFCfights.Models;

namespace UFCfights.Data;

public class FightsContext : DbContext
{
    public FightsContext(DbContextOptions<FightsContext> options) : base(options) { }
    public DbSet<Fight> Fights => Set<Fight>();
}
