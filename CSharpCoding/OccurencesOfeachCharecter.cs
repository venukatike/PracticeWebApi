using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoding
{
    public class OccurencesOfeachCharecter
    {

       
        public void Occurences(string input)
        {
          var charCounts = input
          .GroupBy(c => c)           // Group by each character
          .Select(g => new { Char = g.Key, Count = g.Count() }) // Get count
          .ToList();

            // Display results
            foreach (var item in charCounts)
            {
                Console.WriteLine($"{item.Char} -> {item.Count}");
            }
           


            /*    
             
            Dictionary<char, int> dist = new Dictionary<char, int>();

                foreach(char i in input)
                {
                    if (i != ' ')  //Ignore the spaceses
                    {
                        if(dist.ContainsKey(i)) 
                        {
                            dist[i]++;
                        }
                        else
                        {
                            dist[i] = 1;
                        }
                    }
                } 

            foreach (var v in dist)
            {
                Console.WriteLine($"{ v.Key} = {v.Value}");
            } 
            
           */
        }
    }
}
