using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameReviews.Models;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[Authorize]
public class GameController : ControllerBase
{
    private readonly GameReviewContext _context;

    public GameController(GameReviewContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Game>>> GetGames()
    {
        return await _context.Games.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetGame(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null)
        {
            return NotFound();
        }
        return game;
    }

    [HttpPost]
    public async Task<ActionResult<Game>> PostGame(Game game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutGame(int id, Game game)
    {
        if (id != game.Id)
        {
            return BadRequest();
        }
        _context.Entry(game).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Games.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null)
        {
            return NotFound();
        }
        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("ByGenre")]
    public async Task<ActionResult<IEnumerable<Game>>> GetGamesByPlatform(string platform)
    {
        var games = await _context.Games.Where(g => g.Platform == platform).ToListAsync();
        return games;
    }

    [HttpGet("ByPublisher")]
    public async Task<ActionResult<IEnumerable<IGrouping<int, Game>>>> GetGamesGroupedByPublisher()
    {
        var gamesGroupedByPublisher = await _context.Games
            .GroupBy(g => g.PublisherId)
            .ToListAsync();
        return gamesGroupedByPublisher;
    }

    [HttpGet("WithPublisher")]
    public async Task<ActionResult<IEnumerable<object>>> GetGamesWithPublishers()
    {
        var gamesWithPublishers = await _context.Games
            .Join(_context.Publishers,
                  game => game.PublisherId,
                  publisher => publisher.Id,
                  (game, publisher) => new { Game = game, Publisher = publisher })
            .ToListAsync();
        return gamesWithPublishers;
    }


    [HttpGet("WithReviews")]
    public async Task<ActionResult<IEnumerable<Game>>> GetGamesWithReviews()
    {
        var gamesWithReviews = await _context.Games
            .Include(g => g.Reviews)
            .ToListAsync();
        return gamesWithReviews;
    }
}
