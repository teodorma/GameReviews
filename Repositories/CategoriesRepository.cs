using GameReviews.Data;
using GameReviews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GameReviews.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {   
        private readonly GameReviewContext context;
        public CategoriesRepository(GameReviewContext context) { 
            this.context = context;
        }
        public async Task CreateCategory(Category c)
        {
            await context.Categories.AddAsync(c);
            await context.SaveChangesAsync();
        }
        public async Task DeleteCategory(Category cat)
        {
            context.Categories.Remove(cat);
            await context.SaveChangesAsync();
        }
        public async Task<Category> findbyname(string nume)
        {
            var category = await context.Categories.Where(cat => cat.Name.Contains(nume)).FirstOrDefaultAsync();
            if (category == null) { throw new Exception("nu exista"); }
            return category;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }
        public async Task<Category> findbyid(int id)
        {
            var category = await context.Categories.FirstOrDefaultAsync(cat => cat.Id == id);
            if (category == null) { throw new Exception("nu exista"); }
            return category;
        }

        public async Task PutCategory(int id, Category category)
        {
            context.Categories.Update(category);
            await context.SaveChangesAsync();
        }
    }
}
