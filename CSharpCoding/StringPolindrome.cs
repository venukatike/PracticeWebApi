using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoding
{
    public class StringPolindrome
    {
        public string Polindrome(string input)
        {
            string str = new string(input.Reverse().ToArray());

            if (input == str)
            {
                return input + " is a Polindrome";
            }
            else
            {
                return input + " is Not a Polindrome";
            }

        }
        
    }
}
