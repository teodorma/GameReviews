using GameReviews.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameReviews.Repositories
{
    public interface IGamesRepository
    {
        Task<IEnumerable<Game>> GetGamesAsync();
        Task<Game> GetGameByIdAsync(int id);
        Task AddGameAsync(Game game);
        Task<bool> UpdateGameAsync(Game game);
        Task<bool> DeleteGameAsync(int id);
    }
}
