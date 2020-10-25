using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/*2 in 15 POW = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

What is the sum of the digits of the number 2 in 1000 POW?*/

namespace Problem16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n"+PowerDigitSum(2, 1000));
            Console.ReadLine();
        }
        static int PowerDigitSum(int s, int power)
        {
            BigInteger result = new BigInteger();
            int output = 0;
            result = (BigInteger)Math.Pow(s, power);
            Console.WriteLine(result);

            while (result > 0)
            {
                output += (int)(result % 10);
                result /= 10;
            }
            
            return output;
        }
    }
}
