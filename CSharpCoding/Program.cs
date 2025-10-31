
using System;
using System.Collections;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using CSharpCoding;

namespace CSharpCoding
{
   // public delegate void MyD(string message);
    static class Program
    {
        public static void Main(string[] args)
        {
            int c=10;
           
            Console.WriteLine(c.);  
        }

        public static void AddNumbers(int a)
        {
            Console.WriteLine(a);
        }



    }
}



/*

using System;
using System.Collections;
using System.Linq;

namespace CSharpCoding
{
   class Program
   {
       //public class Employee
       //{
       //    public string EmployeeId { get; set; }
       //    public string FirstName { get; set; }
       //}

       //Get all employees whose name starts with ‘A’. in C# or LINQ
       public static void Main(string[] args)
       {


           /* string[] input = { "Anmol", "Ayush", "Rajesh","Rajendran", "Mallesh" };

            var output = input.Where(e => e.StartsWith("A")).ToArray();

            foreach (var res in output)
            {
                Console.WriteLine(res);
            } 


        List<Employee> employees = new List<Employee>
        {
            new Employee { EmployeeId = "1", FirstName = "Alex" },
            new Employee { EmployeeId = "2", FirstName = "John" },
            new Employee { EmployeeId = "3", FirstName = "Andrew" },
            new Employee { EmployeeId = "4", FirstName = "Michael" }
        };


            var t = employees.Where(e => e.FirstName.StartsWith("A")).ToList();

            foreach (var n in t)
            {
                Console.WriteLine(n.FirstName + "->" + n.EmployeeId);
            }
        } 
//Solution solution = new Solution();
//solution.IsPalindrome("A man, a plan, a canal: Panamap");


//PalindromeNumber palindromeNumber = new PalindromeNumber();

//palindromeNumber.IsPalindromeNumber();

//string input = Console.ReadLine();
//bool isPalindrome = input.SequenceEqual(input.Reverse());

//Console.WriteLine(isPalindrome);

NumbersSum sum = new NumbersSum();

Console.WriteLine(sum.SumOfNumbers(12900903));

int[] arr = { 12, 35, 1, 10, 34, 1 };
Console.WriteLine(ArraySecondLargestElement.SecondLargestElement(arr));

        }
    }
}
*/
