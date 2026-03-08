using EmployeeAPI.Dtos;
using EmployeeAPI.Dtos.Employee;
using EmployeeAPI.Models;
using EmployeeAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<JsonResultModel> CreateEmployee(CreateEmployeeDto dto)
        {
            var existCode = await _dbContext.Employees
                .Where(a => a.Code == dto.Code && a.IsActive == true)
                .FirstOrDefaultAsync();
            if (existCode != null) return JsonResponse.Error(0, "Mã nhân viên đã tồn tại");

            var employee = new Employee
            {
                Name = dto.Name,
                Phone = dto.Phone,
                Address = dto.Address,
                Code = dto.Code,
                Email = dto.Email,
                Dob = dto.Dob
            };

            await _dbContext.Employees.AddAsync(employee);

            await _dbContext.SaveChangesAsync();

            return JsonResponse.Success(new { Id = employee.Id });
        }

        public async Task<JsonResultModel> DeleteEmployee(int id)
        {
            var employee = await _dbContext.Employees.Where(a => a.Id == id && a.IsActive == true).FirstOrDefaultAsync();
            if (employee == null) return JsonResponse.Error(0, "Nhân viên không tồn tại");

            employee.IsActive = false;
            await _dbContext.SaveChangesAsync();
            return JsonResponse.Success();
        }

        public async Task<JsonResultModel> EditEmployee(int id, CreateEmployeeDto dto)
        {
            var existCode = await _dbContext.Employees
                .Where(a => a.Code == dto.Code && a.Id != id && a.IsActive == true)
                .FirstOrDefaultAsync();
            if (existCode != null) return JsonResponse.Error(0, "Mã nhân viên đã tồn tại");

            var employee = await _dbContext.Employees.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (employee == null)
            {
                return JsonResponse.Error(0, "Nhân viên không tồn tại");
            }

            employee.Name = dto.Name;
            employee.Phone = dto.Phone;
            employee.Address = dto.Address;
            employee.Code = dto.Code;
            employee.Email = dto.Email;
            employee.Dob = dto.Dob;

            await _dbContext.SaveChangesAsync();

            return JsonResponse.Success(new { });
        }

        public async Task<JsonResultModel> GetEmployeeDetails(int id)
        {
            var model = await _dbContext.Employees.Where(a => a.IsActive == true
                && a.Id == id
                ).Select(a => new GetEmployeeDetailsModel
                {
                    Id = a.Id,
                    CreatedDate = a.CreatedDate,
                    Code = a.Code,
                    Name = a.Name,
                    Phone = a.Phone,
                    Dob = a.Dob,
                    Email = a.Email,
                    Address = a.Address
                }).FirstOrDefaultAsync();

            return JsonResponse.Success(model);
        }

        public async Task<JsonResultModel> GetListEmployee(int page, int limit, string? search, DateTime? fromDate, DateTime? toDate)
        {
            page = page < 1 ? 1 : page;
            limit = limit < 1 ? 12 : limit;

            var query = _dbContext.Employees.Where(a => a.IsActive == true
                && (!string.IsNullOrEmpty(search) ? a.Name.ToLower().Contains(search.ToLower()) || a.Code.ToLower().Contains(search.ToLower()) : true)
                && (fromDate.HasValue ? a.CreatedDate >= fromDate : true)
                && (toDate.HasValue ? a.CreatedDate <= toDate : true)
            );
            var count = await query.CountAsync();
            var list = await query.OrderByDescending(a => a.Id).Select(a => new GetListEmployeeModel
            {
                Id = a.Id,
                CreatedDate = a.CreatedDate,
                Code = a.Code,
                Name = a.Name,
                Phone = a.Phone,
                Dob = a.Dob,
                Email = a.Email,
                Address = a.Address
            }).Skip((page - 1) * limit).Take(limit).ToListAsync();

            return JsonResponse.SuccessPaging(list, new PagingModel
            {
                Page = page,
                Limit = limit,
                TotalItemCount = count
            });
        }
    }
}
