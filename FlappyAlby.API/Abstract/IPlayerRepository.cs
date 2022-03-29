namespace FlappyAlby.API.Abstract;

using DTOs;

public interface IPlayerRepository
    {
        Task<IEnumerable<PlayerDto>> GetTopTen();
        Task<PlayerDto> Create(PlayerDto player);
    }

