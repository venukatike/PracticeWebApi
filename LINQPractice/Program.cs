

//using System.Collections.Generic;
//using System.Linq;
//using LINQPractice;

//var departments = new List<Department>
//{
//    new Department { Name = "HR", Employees = new List<string> { "Alice", "Bob" } },
//    new Department { Name = "IT", Employees = new List<string> { "Charlie", "David" } }
//};

//var deptEmployees = departments.Select(d => d.Employees).ToList();

//foreach (var department in deptEmployees)
//{
//    Console.WriteLine(department);
//}


using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a number between 1 and 3:");
        int number = Convert.ToInt32(Console.ReadLine());

        switch (number)
        {
            case 1:
                Console.WriteLine("You selected One.");
                break;

            case 2:
                Console.WriteLine("You selected Two.");
                break;

            case 3:
                Console.WriteLine("You selected Three.");
                break;

            default:
                Console.WriteLine("Invalid selection.");
                break;
        }
    }
}