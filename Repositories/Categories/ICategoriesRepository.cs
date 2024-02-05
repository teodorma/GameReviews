using GameReviews.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameReviews.Repositories.Categories
{
    public interface ICategoriesRepository
    {
        Task CreateCategory(Category c);
        Task DeleteCategory(Category cat);
        Task<Category> findbyname(string name);
        Task PutCategory(int id, Category category);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> findbyid(int id);
    }
}


