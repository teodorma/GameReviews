using GameReviews.Models;

namespace GameReviews.Services
{
    public interface ICategoriesService
    {
        Task CreateCategory(CategoryDTO category);
    }
}
