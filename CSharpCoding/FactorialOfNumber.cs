
/* 💡 Problem Statement
 * Q. Find the factorial of a given number n. ?
 * Factorial Means multiplying all smaller numbers of n till 1
 * Example :
 *          5! = 5 × 4 × 3 × 2 × 1 = 120
 *          4! = 4 × 3 × 2 × 1 = 24
 *          0! = 1 (by rule)
*/

using System.Numerics;

namespace CSharpCoding
{
    public class FactorialOfNumber
    {
       
        public int FactorialNumber(int n)
        {
         

            /*
             * Factorial of 56 is: 0 — happens because integer overflow occurred.
             * we are using int, which can store values only up to 2,147,483,647
             * But 56! (factorial of 56) is a very large number — roughly 7.1 × 10^74, 
             * which is way beyond the limit of int (or even long).
             * To Fix: Use BigInteger C# provides a special type for huge numbers — BigInteger (in System.Numerics).
             */

            //int fact = 1;

            //for (int i = 1; i <= n; i++)
            //{
            //   fact = fact * i;  // 1 × 1 = 1 -> 1 × 2 = 2 -> 3 × 2 = 6 -> 6 × 4  = 24
            //}

            //Console.WriteLine($"Factorial of {n} is: {fact}");


            // 2️ Recursive Approach

            if (n == 0 || n == 1)
               return 1;
            return n * FactorialNumber(n - 1);
        }
    }
}
