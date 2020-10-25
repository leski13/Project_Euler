using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Problem29
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(distinctPowers());
            Console.ReadLine();
        }

        static int distinctPowers()
        {
            List<BigInteger> output = new List<BigInteger>();
            for(int x = 2; x < 101; x++)
            {
                for(int y = 2; y < 101; y++)
                {
                    BigInteger result = (BigInteger)Math.Pow(x, y);
                    output.Add(result);
                }
            }
            return output.GroupBy(x => x).Count();
        }
    }
}
