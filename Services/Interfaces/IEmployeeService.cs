using EmployeeAPI.Dtos;
using EmployeeAPI.Dtos.Employee;

namespace EmployeeAPI.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<JsonResultModel> GetListEmployee(int page, int limit, string? search, DateTime? fromDate, DateTime? toDate);
        Task<JsonResultModel> GetEmployeeDetails(int id);
        Task<JsonResultModel> CreateEmployee(CreateEmployeeDto dto);
        Task<JsonResultModel> EditEmployee(int id, CreateEmployeeDto dto);
        Task<JsonResultModel> DeleteEmployee(int id);
    }
}
