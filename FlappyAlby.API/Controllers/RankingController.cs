using Microsoft.AspNetCore.Mvc;

namespace FlappyAlby.API.Controllers;

using Bogus;
using DTOs;
using Abstract;

[ApiController]
[Route("[controller]")]
public class RankingController : ControllerBase
{
   private readonly ILogger<RankingController> _logger;
    private readonly IPlayerRepository _playerRepository;

    public RankingController(ILogger<RankingController> logger, IPlayerRepository playerRepository)
    {
        _logger = logger;
        _playerRepository = playerRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _playerRepository.GetTopTen();
        return Ok(result);
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] PlayerDto player)
    {
        return Ok();
    }
}