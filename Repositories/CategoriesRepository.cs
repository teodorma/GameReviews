using GameReviews.Data;
using GameReviews.Models;

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
    }
}
