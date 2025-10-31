using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoding
{
    public class StartsWithChar1
    {
        public void startWithALetter(string[] input)
        {
            var output = input.Where(e => e.StartsWith("V")).ToList();

            foreach(var res in output)
            {
                Console.WriteLine(res);
            }
        }
    }
}
