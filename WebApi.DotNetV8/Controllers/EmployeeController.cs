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


        [HttpGet("api/GetEmployees_nth_HighestSalary/{nth_HighestSalary}")]
        public dynamic GetEmployees_nth_HighestSalary(int nth_HighestSalary)
        {
            return _employee.GetEmployees_nth_HighestSalary(nth_HighestSalary);
        }




        [HttpPost("api/Post")]
        public dynamic PostTheEmployee(Employee employee)
        {
            return _employee.PostTheEmployee(employee);
        }
    }
}
