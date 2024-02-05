using GameReviews.Models;

namespace GameReviews.Repositories
{
    public interface ICategoriesRepository
    {
        Task CreateCategory(Category c);
    }
}
