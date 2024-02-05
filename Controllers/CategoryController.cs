using GameReviews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameReviews.Data;
using GameReviews.Services;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoriesService _categoriesService;

    public CategoryController(ICategoriesService context)
    {
        _categoriesService = context;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        return await _categoriesService.GetCategories();
    }

    [HttpGet("{id}")]
    public async Task<CategoryDTO> GetCategory(int id)
    {
        return await _categoriesService.GetCategory(id);

    }

    [HttpPost]
    public async Task<ActionResult> CreateCategory(CategoryDTO category)
    {
        await _categoriesService.CreateCategory(category);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategory(int id, CategoryDTO category)
    {
        await _categoriesService.PutCategory(id, category);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(CategoryDTO nume)
    {
        await _categoriesService.DeleteCategory(nume);
        return Ok();
    }
}
