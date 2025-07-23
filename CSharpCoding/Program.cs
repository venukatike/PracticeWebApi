// Write a String reverse without using any bulit- in methods
using System;

class Program
{
    public static void Main(string[] args)
    {
        string input = ReverseString("Venu");

        Console.WriteLine("ReversedString : " +input);
}

    public static string ReverseString(string input)
    {
        string reverse = "" ;
        for (int i = input.Length - 1; i >= 0; i --)
        {
            reverse += input[i];
        }
        return reverse;
    }

}

