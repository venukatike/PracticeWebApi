using Microsoft.EntityFrameworkCore;
using WebApi.DotNetV8.Data;
using WebApi.DotNetV8.DTOs;
using WebApi.DotNetV8.Models;
using WebApi.DotNetV8.Repository.Interfaces;

namespace WebApi.DotNetV8.Repository
{
    public class EmployeeRepo : IEmployee
    {
        private readonly AppDbContext _context;
        public EmployeeRepo(AppDbContext context)
        {
            _context = context;
        }
        public Employee GetEmployeeById(string id)
        {
            return  _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
        }
        public async Task<List<EmployeeDto>> GetEmployees(int pageNumber, int pageSize)
        {
           var result = await _context.Employees.OrderBy(x => x).Select(e => new EmployeeDto{ EmployeeId=e.EmployeeId,FirstName= e.FirstName}).ToListAsync();
            var page = result.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

           return page;
        }
        public async Task<List<Employee>> GetEmployeesExport()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
