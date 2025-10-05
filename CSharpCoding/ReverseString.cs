using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoding
{
    public static class ReverseString
    {
        // string input = "Venu";

        //var str = input.Reverse().ToArray();  built-in  methods
        public static string Reverse(string input)
        {
            string reverse = "";
           
            for(int i = input.Length - 1; i >= 0; i--)
            {
                reverse+= input[i];
            }
            return reverse;
        }
    }
}
