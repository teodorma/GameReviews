using GameReviews.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace GameReviews.Services.Categories
{
    public interface ICategoriesService
    {
        Task CreateCategory(CategoryDTO c);
        Task DeleteCategory(CategoryDTO cat);
        Task<Category> findbyname(string name);
        Task PutCategory(int id, CategoryDTO category);
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategory(int id);
    }
}
