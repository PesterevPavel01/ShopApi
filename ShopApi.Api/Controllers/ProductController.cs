using Microsoft.AspNetCore.Mvc;
using ShopApi.Domain.Dto;
using ShopApi.Domain.Interfaces.Services;

namespace ShopApi.Api.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly ICommonService<ProductDto, int> _productService;

        public ProductController(ICommonService<ProductDto, int> productService)
        {
            _productService=productService;
        }

        [HttpGet("test")]
        public IActionResult TestController()
        {
            return Ok("EmployeeController работает!");
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ProductDto>> GetEmployeeById(short id)
        {
            var response = await _productService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet()]
        public async Task<ActionResult<List<ProductDto>>> GetEmployees()
        {

            var response = await _productService.GetAllAsync();

            return Ok(response);

        }

        [HttpPost()]
        public async Task<ActionResult<ProductDto>> CreateEmployee([FromBody] ProductDto product)
        {
            var response = await _productService.CreateAsync(product);

            return Ok(response);
        }

        [HttpPatch()]
        public async Task<ActionResult<ProductDto>> UpdateEmployee([FromBody] ProductDto product)
        {

            var response = await _productService.UpdateAsync(product);

            return Ok(response);

        }

        [HttpDelete()]
        public async Task<ActionResult<ProductDto>> DeleteEmployee([FromBody] short id)
        {
            var response = await _productService.DeleteAsync(id);

            return Ok(response);

        }
    }
}
