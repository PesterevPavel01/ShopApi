using Microsoft.AspNetCore.Mvc;
using ShopApi.Domain.Dto;
using ShopApi.Domain.Interfaces.Services;

namespace ShopApi.Api.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private readonly ICommonService<EmployeeDto, int> _employeeService;

        public EmployeeController(ICommonService<EmployeeDto, int> employeeService)
        {
            _employeeService=employeeService;
        }

        [HttpGet("test")]
        public IActionResult TestController()
        {
            return Ok("EmployeeController работает!");
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(short id)
        {
            var response = await _employeeService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet()]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployees()
        {

            var response = await _employeeService.GetAllAsync();

            return Ok(response);

        }

        [HttpPost()]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee([FromBody] EmployeeDto employee)
        {
            var response = await _employeeService.CreateAsync(employee);

            return Ok(response);
        }

        [HttpPatch()]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee([FromBody] EmployeeDto employee)
        {

            var response = await _employeeService.UpdateAsync(employee);

            return Ok(response);

        }

        [HttpDelete()]
        public async Task<ActionResult<EmployeeDto>> DeleteEmployee([FromBody] short id)
        {
            var response = await _employeeService.DeleteAsync(id);

            return Ok(response);

        }
    }
}
