namespace FlappyAlby.API.Data;

using Domain;
using Microsoft.EntityFrameworkCore;

public class FlappyDbContext : DbContext
{
    public DbSet<Player> Players { get; set; } = null!;
    
    public FlappyDbContext(DbContextOptions options) : base(options)
    {
    }
}