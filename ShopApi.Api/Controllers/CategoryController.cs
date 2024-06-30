using Microsoft.AspNetCore.Mvc;
using ShopApi.Domain.Dto;
using ShopApi.Domain.Interfaces.Services;

namespace ShopApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICommonService<CategoryDto, int> _categorycervice;

        public CategoryController(ICommonService<CategoryDto, int> categoryservice)
        {
            _categorycervice = categoryservice;
        }

        [HttpGet("test")]
        public IActionResult TestController()
        {
            return Ok("CategporyController работает!");
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CategoryDto>> GetCategoryById(short id)
        {
            var response = await _categorycervice.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet()]
        public async Task<ActionResult<List<CategoryDto>>> GetCategory()
        {

            var response = await _categorycervice.GetAllAsync();

            return Ok(response);

        }

        [HttpPost()]
        public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CategoryDto category)
        {
            var response = await _categorycervice.CreateAsync(category);

            return Ok(response);
        }

        [HttpPatch()]
        public async Task<ActionResult<CategoryDto>> UpdateCategory([FromBody] CategoryDto category)
        {

            var response = await _categorycervice.UpdateAsync(category);

            return Ok(response);

        }

        [HttpDelete()]
        public async Task<ActionResult<CategoryDto>> DeleteCategory([FromBody] short id)
        {
            var response = await _categorycervice.DeleteAsync(id);

            return Ok(response);

        }
    }
}
