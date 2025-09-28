using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoding
{
    public static class ArraySecondLargestElement
    {
        public static void SecondLargestElement(int[] arr)
        {
            int first = int.MinValue;  //-214847
            int second = int.MinValue;  // -214847

            for (int i = 0; i <= arr.Length - 1; i++)
            {
                if (arr[i] > first)
                {
                    second = first;  //second = 20
                    first = arr[i];  // first = 60
                }
                else if (arr[i] > second && arr[i] != first)
                {
                    second = arr[i];
                }
            }
            Console.WriteLine("second element is :" + second);

        }
    }
}
