using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

/*A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 
 * 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.*/

namespace Problems23
{
    class Program
    {
        const int limit = 28123;
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(Sum(NonAbundantList()));
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }

        static List<int> NonAbundantList()
        {
            List<int> nonAbundant = new List<int>();
            for (int s = 2; s < limit; s++)
            {
                int divider = 0;
                for (int d = 1; d < (s / 2 + 1); d++)
                    if (s % d == 0) divider += d;

                if (divider > s)
                    nonAbundant.Add(s);//в список добавляются числа, у которых сумма делителей больше самого числа
            }
            return nonAbundant;
        }
        static int Sum(List<int> input)
        {
            List<int> all = Enumerable.Range(1, 28123).ToList();
            for(int x = 0; x < input.Count; x++)
            {
                for(int y = 0; y < input.Count; y++)
                {
                    int res = input[x] + input[y];
                    if (res > limit) 
                        break;
                    all[res-1] = 0;//потому что индекс массива начинается с 0
                }
            }
            return all.Sum();
        }
    }
}
