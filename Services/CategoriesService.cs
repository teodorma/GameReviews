using GameReviews.Models;
using GameReviews.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameReviews.Services
{
    public class CategoriesService : ICategoriesService
    {
       private readonly CategoriesRepository repository;
       public CategoriesService(CategoriesRepository repository) { 
            this .repository = repository;
       }
        public async Task CreateCategory(CategoryDTO category)
        {
            var categorie = new Category() { Name = category.name, Description = category.description };
            await repository.CreateCategory(categorie);
        }
    }
}
