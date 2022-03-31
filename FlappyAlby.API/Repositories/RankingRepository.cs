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

    public async Task<IEnumerable<RankingDto>> GetTop10()
    {
        var rank = await _context.Ranking
            .Include(r => r.Player)
            .OrderBy(r => r.Total).Take(10)
            .ToListAsync();
        
        return rank.Select(r => new RankingDto(r.Player!.Name, r.Total));
    }

    public async Task<bool> Create(RankingDto ranking)
    {
        var player = await _context.Players.SingleOrDefaultAsync(p => p.Name == ranking.PlayerName);

        if (player is null)
        {
            var added = await _context.Players.AddAsync(new Player(ranking.PlayerName));
            player = added.Entity;
            await _context.SaveChangesAsync();
        }

        var entity = new Ranking((int) player.Id!, ranking.Total);
        
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        
        return true;
    }
}