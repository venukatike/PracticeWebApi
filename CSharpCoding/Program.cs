
// Find the second largest element in an array 

using System;
using CSharpCoding;

class Program
{
    public static void Main(string[] args)
    {
        string input = "VVeennuu";

        StringPolindrome polindrome = new StringPolindrome();

        OccurencesOfeachCharecter occurences = new OccurencesOfeachCharecter();

        occurences.Occurences(input);
        
        Console.WriteLine(polindrome.Polindrome(input));

        Console.Write(ReverseString.Reverse(input));

        // int[] arr = { 1, 2, 3, 4, 5 };
        // ArraySecondLargestElement.SecondLargestElement(arr);
    }

    public class Person
    {
        public string Name = "koma";
    }
}

 
