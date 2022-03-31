namespace FlappyAlby.API.Data;

using Domain;
using Microsoft.EntityFrameworkCore;

public class FlappyDbContext : DbContext
{
    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Ranking> Ranking { get; set; } = null!;
    
    public FlappyDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var player = modelBuilder.Entity<Player>();
        player.HasKey(p => p.Id);
        player.HasIndex(p => p.Name).IsUnique();
        player.Property(p => p.Name).HasMaxLength(20).IsRequired();

        var ranking = modelBuilder.Entity<Ranking>();
        ranking.HasKey(r => r.Id);
        ranking.Property(r => r.Total).IsRequired();
        
        ranking
            .HasOne(r => r.Player)
            .WithMany(p => p.Rankings)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(r => r.PlayerId);
    }
}