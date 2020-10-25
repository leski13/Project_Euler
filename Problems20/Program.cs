using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
/*n! means n × (n − 1) × ... × 3 × 2 × 1

For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

Find the sum of the digits in the number 100!*/
namespace Problems20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(100));
            Console.ReadLine();
        }
        static int Factorial(int x)
        {
            BigInteger big = new BigInteger();
            big = 1;
            for(int s = x; s > 1; s--)
            {
                big *=s;
            } 
            
            return digitSum(big);
        }
        static int digitSum(BigInteger big)
        {
            int output = 0;
            while (big > 1)
            {
                output += (int)(big % 10);
                big /= 10;
            }
            return output;
        }
    }
}
