using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

        public List<Employee> GetEmployees_nth_HighestSalary(int nth_HighestSalary)
        {
            var nth_HighestSalaries = _context.Employees.Select(e => e.Salary)   // take only salaries
                                         .Distinct()                            // remove duplicates
                                         .OrderByDescending(s => s)             // sort highest to lowest
                                         .Skip(nth_HighestSalary - 1)            // skip the highest
                                         .FirstOrDefault();                     // take the 2nd highest
            
            return _context.Employees.Where(e => e.Salary == nth_HighestSalaries).ToList();

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

        public IActionResult PostTheEmployee(Employee employee)
        {
            if (employee == null)
            {
                return new BadRequestResult();
            }

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return new OkResult();
        }
    }
}
