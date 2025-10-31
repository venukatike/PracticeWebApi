
// Q. Given Number is Polindrome Number or Not ?

namespace CSharpCoding
{
    public class PalindromeNumber
    {
       // A palindrome number is a number that reads the same forwards and backward   123
       public void IsPalindromeNumber()
        {
            int num = int.Parse(Console.ReadLine());
            int original = num;
            int reversed = 0;

            while (num > 0)
            {
                int digit = num % 10;  // 1%10 = 1
                reversed = reversed * 10 + digit;  // 32*10 + 1 = 321
                num /= 10;  // 1/10 = 0.1 = 0
            }
            if (original == reversed)
            {
                Console.WriteLine(reversed +" is a Palindrome Number");
            }
            else
            {
                Console.WriteLine(reversed +" Not a Palindrome Number");
            }
        }
    }
}
