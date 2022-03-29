using FlappyAlby.API.Abstract;
using FlappyAlby.API.Domain;
using FlappyAlby.API.DTOs;

namespace FlappyAlby.API.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;
        public PlayerRepository(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public async Task<PlayerDto> Create(PlayerDto player)
        {
            const string query = @"INSERT INTO Player
                                ([Name] ,[Total])
                                VALUES (@Name, @Total)";
            var newPlayer = new Player(default, player.Name, player.Total);
            var newId = await _writer.WriteAsync(query, newPlayer);            
            return new PlayerDto 
            { 
                Id = newPlayer.Id, 
                Name = newPlayer.Name,
                Total = newPlayer.Total
            };
        }

        public async Task<IEnumerable<PlayerDto>> GetTopTen()
        {
            const string query = @"SELECT TOP (10) Id, Name, Total
                                   FROM   dbo.Player
                                   ORDER BY Total ";
            var topTen = await _reader.QueryAsync<Player>(query);
            var topTenDto = new List<PlayerDto>();
            foreach (var player in topTen)
            {
                topTenDto.Add(
                    new PlayerDto()
                    {
                        Name = player.Name,
                        Total = player.Total,
                        Id = player.Id
                    }
                );
            }
            return topTenDto;
        }
    }
}
