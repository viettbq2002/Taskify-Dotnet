using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskify.Application.DTOs.ItemCategory;
using Taskify.Application.Interfaces;

namespace Taskify.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateItemCategory request)
        {
            var response = await _categoryService.CreateAsync(request);
            return Created(string.Empty,response);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory(bool isArchived = false)
        {
            var reponse = await _categoryService.GetListAsync(isArchived);
            return Ok(reponse);
        }
        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var response = await _categoryService.GetAsync(categoryId);
            return Ok(response);

        }
     
    }
}
