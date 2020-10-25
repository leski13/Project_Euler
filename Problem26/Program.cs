using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

//Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.

namespace Problem26
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(reciprocalCycles(PrimeNumber()));
            Console.ReadLine();
        }
        static BigInteger reciprocalCycles(List<int> input)
        {
            BigInteger number=0;
            BigInteger integer = new BigInteger();
            for(int s = input.Count; s > 1; s--)
            {
                number = input[s-1];
                int count = input[s-1];
                StringBuilder sb = new StringBuilder();
                sb.Insert(0, "0", count);
                integer = BigInteger.Parse("1" + sb);
                number = integer/input[s-1];
                string output = number.ToString();
                string check = output.Substring(0, 10);
                if (!output.Substring(11, output.Length/2).Contains(check))
                {
                    return number;
                }               
            }
            return number;
        }
        static List<int> PrimeNumber()
        {
            List<int> vs = new List<int>() { 2, 3, 5, 7 };
            int count = 4;
            int s = 9;

            for (s = 9; s < 1000; s += 2)//с шагом +=2 колличество проверок уменьшиться в 2 раза
            {
                if (s % 3 == 0 || s % 5 == 0)// на 3 делится 33% чисел среди оставшихся, на 5 - 20%
                    continue;

                else
                {
                    for (int d = 3; d < count;)//цикл по списку
                    {
                        if (s % vs[d] == 0) { break; }
                        if (s % vs[d] != 0 && d == count - 1)//проверка числа по списку простых чисел. 
                        {
                            vs.Add(s);
                            count++;
                            break;
                        }
                        d++;
                    }
                }
            }
            return vs;
        }
    }
}
