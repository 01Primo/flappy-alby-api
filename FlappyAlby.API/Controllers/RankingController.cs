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
    private readonly IRankingRepository _rankingRepository;

    public RankingController(IRankingRepository rankingRepository, ILogger<RankingController> logger)
    {
        _rankingRepository = rankingRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        try
        {
            var result = await _rankingRepository.GetTop10();
            return Ok(result);
        }
        catch (Exception e)
        {
            return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PlayerDto player)
    {
        try
        {
            _ = await _rankingRepository.Create(player);
            return Ok();
        }
        catch(Exception e)
        {
            return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}