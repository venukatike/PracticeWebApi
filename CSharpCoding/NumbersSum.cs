using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoding
{
    public class NumbersSum
    {
        public int SumOfNumbers(int num)  // 123
        {
            int results=0;
         

            while (num> 0)
            {
                int sum = num % 10; 
                num = num / 10;
                results = results * 10 + sum;
            }

            return results;
        }
    }
}

//Input: 123
//Step 1: result = 0 * 10 + 3 → 3
//Step 2: result = 3 * 10 + 2 → 32
//Step 3: result = 32 * 10 + 1 → 321
//Output: 321
