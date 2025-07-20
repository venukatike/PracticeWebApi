using System.Text;
using Microsoft.AspNetCore.Mvc;
using WebApi.DotNetV8.DTOs;
using WebApi.DotNetV8.Models;
using WebApi.DotNetV8.Repository.Interfaces;

namespace WebApi.DotNetV8.Controllers
{
    public class EmployeeController : Controller
    {
        readonly ILogger<EmployeeController> _logger;
        private readonly IEmployee _employee;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployee employee)
        {
            _logger = logger;
            _employee = employee;
            
        }

        [HttpGet("api/employee")]
        public async Task<List<EmployeeDto>> GetAllEmployees(int pageNumber,int pageSize)
        {
            return await _employee.GetEmployees(pageNumber,pageSize);
        }

        [HttpGet("api/GetEmployee/{id}")]
        public dynamic GetEmployeeById(string id)
        {
            return _employee.GetEmployeeById(id);
        }

        [HttpGet("api/export-employees")]
        public async Task<IActionResult> ExportEmployees()
        {
            var employees = await _employee.GetEmployeesExport();

            var sb = new StringBuilder();
            sb.AppendLine("Id,Name,Department,Salary");

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.EmployeeId},{emp.FirstName},{emp.Department},{emp.Salary}");
            }

            var bytes = Encoding.UTF8.GetBytes(sb.ToString());
            return File(bytes, "text/csv", "employees.csv");
        }
    }
}
