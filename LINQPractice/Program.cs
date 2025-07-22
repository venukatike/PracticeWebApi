

using System.Collections.Generic;
using System.Linq;
using LINQPractice;

var departments = new List<Department>
{
    new Department { Name = "HR", Employees = new List<string> { "Alice", "Bob" } },
    new Department { Name = "IT", Employees = new List<string> { "Charlie", "David" } }
};

var deptEmployees = departments.Select(d => d.Employees).ToList();

foreach (var department in deptEmployees)
{
    Console.WriteLine(department);
}
