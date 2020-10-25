using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem13
{
    //Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(largeSum());
            Console.ReadLine();
        }

        public static string largeSum()
        {
            string output = "";
            string fileName = @"C:\Users\acer\source\repos\Project_Euler\Problem13\bin\Debug\large.txt";
            BigInteger result = new BigInteger();
            string line;

            using(StreamReader reader = new StreamReader(fileName))
            {
                while((line=reader.ReadLine())!=null)
                    result += BigInteger.Parse(line);
            }
            Console.WriteLine(result);
            output = result.ToString().Substring(0, 10);
            return output;
        }
    }
}
