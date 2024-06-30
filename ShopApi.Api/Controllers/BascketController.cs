using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Domain.Dto;
using ShopApi.Domain.Interfaces.Services;

namespace ShopApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BascketController : ControllerBase
    {
        private readonly ICommonService<BascketDto, int> _bascketService;

        public BascketController(ICommonService<BascketDto, int> bascketService)
        {
            _bascketService = bascketService;
        }

        [HttpGet("test")]
        public IActionResult TestController()
        {
            return Ok("BascketController работает!");
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<BascketDto>> GetBascketById(short id)
        {
            var response = await _bascketService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet()]
        public async Task<ActionResult<List<BascketDto>>> GetBasckets()
        {

            var response = await _bascketService.GetAllAsync();

            return Ok(response);

        }

        [HttpPost()]
        public async Task<ActionResult<BascketDto>> CreateBascket([FromBody] BascketDto bascket)
        {
            var response = await _bascketService.CreateAsync(bascket);

            return Ok(response);
        }

        [HttpPatch()]
        public async Task<ActionResult<BascketDto>> UpdateBascket([FromBody] BascketDto bascket)
        {

            var response = await _bascketService.UpdateAsync(bascket);

            return Ok(response);

        }

        [HttpDelete()]
        public async Task<ActionResult<BascketDto>> DeleteBascket([FromBody] short id)
        {
            var response = await _bascketService.DeleteAsync(id);

            return Ok(response);

        }

        [HttpDelete("User")]
        public async Task<ActionResult<int>> DeleteEmployeeEntitys([FromBody] short id)
        {
            var response = await _bascketService.DeleteAsync(id);

            return Ok(response);

        }
    }
}

