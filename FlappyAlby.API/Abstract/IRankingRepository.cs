namespace FlappyAlby.API.Abstract;

using DTOs;

public interface IRankingRepository
{
    Task<IEnumerable<RankingDto>> GetTop10();
    Task<bool> Create(RankingDto player);
}