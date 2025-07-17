using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PracticeWebApi.Data;
using PracticeWebApi.Model;

namespace PracticeWebApi.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        private readonly PracticeDbContext context;
        public HomeController(PracticeDbContext _context)
        {
            context = _context;
        }

        [HttpGet("GetAll")]
        public dynamic GetAllData()
        {
            //first highest salary
            var data = context.Employees.OrderByDescending(x => x.Salary).FirstOrDefault();
            // you will one if you duplicates means A B has same highest salary then use

            var maxSalary = context.Employees.Max(e => e.Salary); //You will get only salary OUTPUT : 50,000
           
            var topEarners = context.Employees
                .Where(e => e.Salary == maxSalary)  
                .ToList();   // multiple records we will get ex. venu ramu has 50,000 as highest salary


            var distinctSalaries = context.Employees
                .Select(e => e.Salary)
                .Distinct()
                .OrderByDescending(s => s)
                .ToList();   // you will get all distincts ex: 50,000, 40,000, 30,000, 20,000

            var secondHighestSalary = distinctSalaries.Skip(1).FirstOrDefault(); //skiping one from all so O/P : 40,000

            var secondHighestEarners = context.Employees
                .Where(e => e.Salary == secondHighestSalary)
                .ToList();



            var departmentCounts = context.Employees
                                    .GroupBy(e => e.Department)
                                    .Select(group => new
                                     {
                                        Department = group.Key,
                                        EmployeeCount = group.Count()
                                     })
                                    .ToList();

             var salary = context.Employees.Where(x => x.Salary>=50000).ToList();
            // var salary = from variab in context.Employees where variab.Salary >= 50000 select variab;
            // var salary = from e in context.Employees where e.Salary >= 50000 select e;

            var ListNum = new List<int> { 1, 7, 9, 4, 2, 3, 4, 5, 6 };


            var squared = ListNum.Select(x => x * 2).ToList();
            var squaredM = from e in ListNum select e * 2;

            return squaredM;
        }
    }
}