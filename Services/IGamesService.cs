using GameReviews.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameReviews.Services
{
    public interface IGamesService
    {
        Task<IEnumerable<GameDTO>> GetGamesAsync();
        Task<GameDTO> GetGameAsync(int id);
        Task CreateGameAsync(GameDTO gameDto);
        Task<bool> UpdateGameAsync(int id, GameDTO gameDto);
        Task<bool> DeleteGameAsync(int id);
    }
}
