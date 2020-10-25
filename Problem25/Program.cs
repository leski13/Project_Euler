using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
//What is the index of the first term in the Fibonacci sequence to contain 1000 digits?
namespace Problem25
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fibonacci());
            Console.ReadLine();
        }
        static int Fibonacci()
        {
            int count = 2;
            BigInteger x = new BigInteger();
            BigInteger y = new BigInteger();
            BigInteger z = new BigInteger();
            x = y = 1;
            z = 0;
            while (true)
            {
                z = x + y;
                string number = z.ToString();
                y = x;
                x = z;
                count++;
                if (number.Length > 999) break;
            }
            return count;
        }
    }
}
