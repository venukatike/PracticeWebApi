using System.Text.RegularExpressions;

public class Solution
{
    public bool IsPalindrome(string s)
    {
       // string cleaned1 = Regex.Replace(s, "[^a-zA-Z0-9]", "").ToLower();

        string cleaned = s.Replace(":", "")
                         .Replace(",", "")
                         .Replace(" ", "")
                         .ToLower();

       // string reverse = new string(cleaned1.Reverse().ToArray());
        /*.Reverse() → reverses the sequence of characters.
          .ToArray() → converts it into a char[].
           new string(...) → constructs a new string from that array. */


        // string reverse = "";   This line creates a new empty string object in memory.
        /*  for(int i = cleaned.Length-1;i>=0;i--)
          {
              reverse+=cleaned[i];
          }*/

        // iHaii
        int left = 0, right = cleaned.Length - 1;
        while (left < right)
        {
         
           

            if (cleaned[left] != cleaned[right])
            {
                Console.WriteLine("Left: " + left + " -> " + cleaned[left] + " != " + "Right: " + left + " -> " + cleaned[right]);
                Console.WriteLine(false);
                return false;
            }
            else
            {
                Console.WriteLine("Left: " + left + " -> " + cleaned[left] + " == " + "Right: " + left + " -> " + cleaned[right]);
            }

                left++;
            right--;
        }
        Console.WriteLine(true);
        return true;


        /*   if(reverse==cleaned){
              return true;
           }
           else{
              return false;
           }  */

    }
}