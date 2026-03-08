using EmployeeAPI.Dtos;
using EmployeeAPI.Dtos.Employee;
using EmployeeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers.App.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<JsonResultModel> GetListEmployee(int page = 1, int limit = 12, string? search = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return await _employeeService.GetListEmployee(page, limit, search, fromDate, toDate);
        }

        [HttpGet("{id}")]
        public async Task<JsonResultModel> GetEmployeeDetails(int id)
        {
            return await _employeeService.GetEmployeeDetails(id);
        }

        [HttpPost]
        public async Task<JsonResultModel> CreateEmployee(CreateEmployeeDto dto)
        {
            return await _employeeService.CreateEmployee(dto);
        }

        [HttpPut("{id}")]
        public async Task<JsonResultModel> EditDepartment(int id, CreateEmployeeDto dto)
        {
            return await _employeeService.EditEmployee(id, dto);
        }


        [HttpDelete("{id}")]
        public async Task<JsonResultModel> DeleteEmployee(int id)
        {
            return await _employeeService.DeleteEmployee(id);
        }
    }
}
