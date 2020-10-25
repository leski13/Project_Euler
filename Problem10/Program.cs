using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem10
{
    //The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

    //Find the sum of all the primes below two million.
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PrimeNumber());
            Console.ReadLine();
            
        }

        public static ulong PrimeNumber()
        {
            List<int> vs = new List<int>() { 2, 3, 5, 7 };
            int count = 4;
            ulong sum = 17;
            int s = 9;

            for (s = 9; s < 2000000; s += 2)//с шагом +=2 колличество проверок уменьшиться в 2 раза
            {
                if (s % 3 == 0 || s % 5 == 0)
                    continue;

                else // на 3 делится 33% чисел среди оставшихся, на 5 - 20%
                {
                    for (int d = 3; d < count;)//цикл по списку
                    {
                        if (s % vs[d] == 0) { break; }
                        if (s % vs[d] != 0 && d == count - 1)//проверка числа по списку простых чисел. 
                        {
                            vs.Add(s);
                            sum += (ulong)s;
                            count++;
                            break;
                        }
                        d++;
                    }
                }
            }

            return sum;
        }
    }
}
