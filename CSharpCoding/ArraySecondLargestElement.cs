using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoding
{
    public static class ArraySecondLargestElement
    {
        public static int SecondLargestElement(int[] arr)
        {
            int n = arr.Length;

            // Sort the array in non-decreasing order
            Array.Sort(arr);

            // start from second last element as last element is the largest
            for (int i = n - 2; i >= 0; i--)
            {

                // return the first element which is not equal to the 
                // largest element
                if (arr[i] != arr[n - 1])
                {
                    return arr[i];
                }
            }

            // If no second largest element was found, return -1
            return -1;
        }





        /*  int first = int.MinValue;  //-214847
          int second = int.MinValue; //-214847

          for (int i = 0; i <= arr.Length - 1; i++)
          {
              if (arr[i] > first)
              {
                  second = first;  
                  first = arr[i];  // first = 60
              }
              else if (arr[i] > first && arr[i] != second)
              {
                  second = arr[i];
              }
          }
          Console.WriteLine("second element is :" + second);
        */
    }
}

