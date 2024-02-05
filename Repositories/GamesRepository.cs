using GameReviews.Data;
using GameReviews.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviews.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly GameReviewContext _context;

        public GamesRepository(GameReviewContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            return await _context.Games
                .Include(g => g.Category) 
                .Include(g => g.Publisher)
                .Include(g => g.Reviews)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task AddGameAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateGameAsync(Game game)
        {
            if (!_context.Games.Any(g => g.Id == game.Id))
            {
                return false;
            }

            _context.Entry(game).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Games.Any(g => g.Id == game.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteGameAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return false;
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
