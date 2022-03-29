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
    public async Task<IActionResult> Post([FromBody] PlayerDto player)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var created = await _playerRepository.Create(player);

            return Ok(created);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}