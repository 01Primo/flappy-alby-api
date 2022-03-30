namespace FlappyAlby.API.Repositories;

using Abstract;
using Data;
using Domain;
using DTOs;
using Microsoft.EntityFrameworkCore;

public class RankingRepository : IRankingRepository
{
    private readonly FlappyDbContext _context;

    public RankingRepository(FlappyDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PlayerDto>> GetTop10()
    {
        var players = await _context.Players.OrderBy(p => p.TotalMilliseconds).Take(10).ToListAsync();
        
        return players.Select(p => new PlayerDto(p.Name, TimeSpan.FromMilliseconds(p.TotalMilliseconds), p.Id));
    }

    public async Task<PlayerDto?> GetById(int id)
    {
        var player = await _context.Players.FindAsync(id);
        
        if (player is null) return null;
        var playerDto = new PlayerDto(
            player.Name,
            TimeSpan.FromMilliseconds(player.TotalMilliseconds),
            player.Id
        );
        return playerDto;
    }

    public async Task<bool> Create(PlayerDto player)
    {
        var entity = new Player(player.Name, (long) player.Total.TotalMilliseconds, player.Id);
        
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        
        return true;
    }
}