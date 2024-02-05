using GameReviews.Models.Publishers;
using GameReviews.Models.Categories;
using GameReviews.Models;
using GameReviews.Repositories.Publishers;
using GameReviews.Repositories.Categories;
using GameReviews.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviews.Services
{
    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IPublisherRepository _publisherRepository;


        public GamesService(IGamesRepository gamesRepository, ICategoriesRepository categoriesRepository)
        {
            _gamesRepository = gamesRepository;
            _categoriesRepository = categoriesRepository;
        }

        public async Task<IEnumerable<GameDTO>> GetGamesAsync()
        {
            var games = await _gamesRepository.GetGamesAsync();
            return games.Select(game => new GameDTO
            {
                Title = game.Title,
                Description = game.Description,
                Platform = game.Platform,
                ReleaseDate = game.ReleaseDate,
                Developer = game.Developer,
                AverageRating = game.AverageRating
            });
        }

        public async Task<GameDTO> GetGameAsync(int id)
        {
            var game = await _gamesRepository.GetGameByIdAsync(id);
            if (game == null) return null;

            return new GameDTO
            {
                Title = game.Title,
                Description = game.Description,
                Platform = game.Platform,
                ReleaseDate = game.ReleaseDate,
                Developer = game.Developer,
                AverageRating = game.AverageRating
            };
        }

        public async Task CreateGameAsync(GameDTO gameDto)
        {
            var category = await _categoriesRepository.findbyname(gameDto.CategoryName);
            var publisher = await _publisherRepository.findbyname(gameDto.CategoryName);
            var game = new Game
            {
                Title = gameDto.Title,
                Description = gameDto.Description,
                Platform = gameDto.Platform,
                ReleaseDate = gameDto.ReleaseDate,
                Developer = gameDto.Developer,
                AverageRating = gameDto.AverageRating,
                Category = category,

                Publisher = new Publisher() { }
            };

            await _gamesRepository.AddGameAsync(game);
        }

        public async Task<bool> UpdateGameAsync(int id, GameDTO gameDto)
        {
            var existingGame = await _gamesRepository.GetGameByIdAsync(id);
            if (existingGame == null) return false;

            existingGame.Title = gameDto.Title;
            existingGame.Description = gameDto.Description;
            existingGame.Platform = gameDto.Platform;
            existingGame.ReleaseDate = gameDto.ReleaseDate;
            existingGame.Developer = gameDto.Developer;
            existingGame.AverageRating = gameDto.AverageRating;

            return await _gamesRepository.UpdateGameAsync(existingGame);
        }

        public async Task<bool> DeleteGameAsync(int id)
        {
            return await _gamesRepository.DeleteGameAsync(id);
        }
    }
}
