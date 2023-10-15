using InvManagement1.models;
using InvManagement1.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InvManagement1.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceCatogory _categoryService;

        public CategoryController(IServiceCatogory categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Catogory>> GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Catogory> GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound(); // Return 404 if the category is not found
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult<Catogory> AddCategory(Catogory category)
        {
            try
            {
                _categoryService.AddCategory(category);
                return CreatedAtAction(nameof(GetCategoryById), new { id = category.CategoryId }, category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Return a 400 Bad Request with an error message
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Catogory category)
        {
            try
            {
                category.CategoryId = id; // Ensure the ID matches the route parameter
                _categoryService.UpdateCategory(category);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message); // Return a 404 Not Found with an error message
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _categoryService.DeleteCategory(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message); // Return a 404 Not Found with an error message
            }
        }
    }
}
