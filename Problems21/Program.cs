using System;
using System.Collections.Generic;
using System.Diagnostics;

/*Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. 
The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

Evaluate the sum of all the amicable numbers under 10000.*/

namespace Problems21
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(AmicableNumbers(10000));
            stopwatch.Stop();
            Console.WriteLine($"\n{stopwatch.Elapsed}");
            Console.ReadLine();
        }
        static int AmicableNumbers(int value)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>() { { 0,0},{1,0},{2,1 },{ 3,1} };
            for(int s = 4; s < value; s++)
            {
                int sumDivider = 0;
                int x = s;
                for(int d = 1; d <= x / 2; d++)
                {
                    if (x % d == 0) sumDivider+=d;
                }
                numbers.Add(s, sumDivider);
            }
            return SearchDictionary(numbers);
        }
        static int SearchDictionary(Dictionary<int, int> input)
        {
            int result = 0;
            for(int s = 0; s < input.Count; s++)
            {
                int key = s;           //key(first ключ) value(second ключ) input[value] input[key]
                int value = input[key];//4                        3               1           3
                
                if (key <= input[key]||input[key]>10000) continue;

                if (key == input[value] && value == input[key])
                    result += key+value;                   
            }
            return result;
        }
    }
}
