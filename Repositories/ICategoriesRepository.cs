using GameReviews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameReviews.Repositories
{
    public interface ICategoriesRepository
    {
        Task CreateCategory(Category c);
        Task DeleteCategory(Category cat);
        Task<Category> findbyname(string name);
        Task PutCategory(int id, Category category);
        Task<IEnumerable<Category>> GetCategories();
        Task <Category> findbyid(int id);   
    }
}


