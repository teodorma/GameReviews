using GameReviews.Models;
using GameReviews.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;

namespace GameReviews.Services
{
    public class CategoriesService : ICategoriesService
    {
       private readonly ICategoriesRepository repository;
       public CategoriesService(ICategoriesRepository repository) { 
            this .repository = repository;
       }
        public async Task CreateCategory(CategoryDTO category)
        {
            var categorie = new Category() { Name = category.name, Description = category.description };
            await repository.CreateCategory(categorie);
        }
        public async Task DeleteCategory(CategoryDTO cat)
        {
            var deSters = await repository.findbyname(cat.name);
            if (deSters == null)
            {
                throw new Exception("nu exista");
            }
            await repository.DeleteCategory(deSters);
        }
        public async Task<Category> findbyname(string name)
        {
            return await repository.findbyname(name);
        }
        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var rez = new List<CategoryDTO>();
            var category = await repository.GetCategories();   
            foreach (var item in category) {
                rez.Add(new CategoryDTO() { description = item.Description, name = item.Name });
            }

            return rez;
        }
        public async Task PutCategory(int id, CategoryDTO category)
        {   
            var categorie = await repository.findbyid(id);
            categorie.Name = category.name;
            categorie.Description = category.description;
            await repository.PutCategory(id,categorie);
        }
        public async Task<CategoryDTO> GetCategory(int id)
        {   

            var c = await repository.findbyid(id);
            return new CategoryDTO() { name= c.Name, description= c.Description };
        }
    }
}
