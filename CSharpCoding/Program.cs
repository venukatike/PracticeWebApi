// Write a String reverse without using any bulit- in methods
using System;


class Program
{
    public static void Main(string[] args)
    {
		Console.WriteLine("Enter the Number : ");
	int number = int.Parse(Console.ReadLine());
		Program program = new Program();
		Console.WriteLine(program.sumOfNumbers(number));
	}

	int t1, results = 0;
    public int sumOfNumbers(int number)
	{
		while(number !=0){
		t1 = number % 10;
		number = number / 10;
        results = results + t1;
}
		return results;
	}

}













