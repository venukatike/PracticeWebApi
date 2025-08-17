using Microsoft.AspNetCore.Mvc;
using WebApi.DotNetV8.DTOs;
using WebApi.DotNetV8.Models;

namespace WebApi.DotNetV8.Repository.Interfaces
{
    public interface IEmployee
    {
        Task<List<EmployeeDto>> GetEmployees(int pageNumber, int pageSize);
        Task<List<Employee>> GetEmployeesExport();
        Employee GetEmployeeById(string id);

        List<Employee> GetEmployees_nth_HighestSalary(int nth_HighestSalary);
        IActionResult PostTheEmployee(Employee employee);
        
    }
}
