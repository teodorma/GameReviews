using Microsoft.AspNetCore.Mvc;
using GameReviews.Models;
using GameReviews.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[Authorize]
public class GameController : ControllerBase
{
    private readonly IGamesService _gamesService;

    public GameController(IGamesService gamesService)
    {
        _gamesService = gamesService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameDTO>>> GetGames()
    {
        var gamesDto = await _gamesService.GetGamesAsync();
        return Ok(gamesDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GameDTO>> GetGame(int id)
    {
        var gameDto = await _gamesService.GetGameAsync(id);
        if (gameDto == null)
        {
            return NotFound();
        }
        return gameDto;
    }

    [HttpPost]
    public async Task<IActionResult> PostGame([FromBody] GameDTO gameDto)
    {
        await _gamesService.CreateGameAsync(gameDto);
        return Ok();
    }

}
