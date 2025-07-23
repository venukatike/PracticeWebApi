// Write a String reverse without using any bulit- in methods
using System;

class Program
{
    public static void Main(string[] args)
    {

        //================ Implemtation ======================
        //2.WRITE A PROGRAM IN C# COUNT THE OCCURRENCE OF EACH CHARACTER IN A STRING.


        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();

        // Dictionary to hold character counts
        Dictionary<char, int> charCount = new Dictionary<char, int>();

        foreach (char c in input)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }

        // Print the results
        Console.WriteLine("\nCharacter Occurrences:");
        foreach (KeyValuePair<char, int> pair in charCount)
        {
            Console.WriteLine($"Character '{pair.Key}' occurs {pair.Value} time(s)");
        }
    }














        
        //string input = ReverseString("Venu");

        //Console.WriteLine("ReversedString : " +input);
    }


    // ================== Mthods ============================



































    //public static string ReverseString(string input)
    //{
    //    string reverse = "" ;
    //    for (int i = input.Length - 1; i >= 0; i --)
    //    {
    //        reverse += input[i];
    //    }
    //    return reverse;
    //}



