using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedbullService.Data;
using RedbullService.Models;

namespace RedbullService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categoryList = await _context.Categories.Select(c => new
            {
                c.category_id,
                c.category_name
            }).ToListAsync();

            if (!categoryList.Any())
                return StatusCode(500);

            return Ok(categoryList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (await _context.Categories.AnyAsync(c => c.category_name == category.category_name))
                return BadRequest("Kategori adı mevcut");

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            // Parola alanını döndür
            var categoryWithPassword = new
            {
                category.category_id,
                category.category_name
            };

            return Ok(categoryWithPassword);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            if (id != category.category_id)
                return BadRequest();

            var categoryExist = await _context.Categories.FindAsync(id);

            if (categoryExist == null)
                return NotFound();

            _context.Entry(categoryExist).CurrentValues.SetValues(category);
            await _context.SaveChangesAsync();

            // Parola alanını döndür
            var updatedCategory = new
            {
                category.category_id,
                category.category_name
            };

            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpGet("count")]
        public async Task<IActionResult> GetCategoryCount()
        {
            var categoryCount = await _context.Categories.CountAsync();

            return Ok(new { categoryCount = categoryCount });
        }
    }
}