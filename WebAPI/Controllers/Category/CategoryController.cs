using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #region # Categories
        [HttpGet]
        public async Task<ActionResult<List<CategoryDetailDto>>> GetCategories()
        {
            var result = await _categoryService.GetCategoriesAsync();
            return Ok(result);
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<CategoryDetailDto>> GetCategoryById(Guid categoryId)
        {
            var result = await _categoryService.GetCategoryByIdAsync(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateDto categoryCreateDto)
        {

            var result = await _categoryService.CreateCategoryAsync(categoryCreateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(Domain.Entities.Category category)
        {
            var result = await _categoryService.UpdateCategoryAsync(category);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            var result = await _categoryService.DeleteCategoryAsync(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
