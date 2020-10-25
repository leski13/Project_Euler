using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem27
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(quadraticPrimes(PrimeNumber()));
            Console.ReadLine();
        }
        static int quadraticPrimes(List<int> input)
        {
            int nValue = 0, aValue = 0, bValue = 0;
            for(int a = -999; a < 1000; a+=2)//n*n+A*n+b
            {
                for(int b=-1001;b<1001;b+=2)//n*n+a*n+B
                {
                    int n = 0;
                    while(input.Contains((int)(Math.Abs(n * n + a * n + b))))
                        n++;
                    if (n > nValue)
                    {
                        nValue = n;
                        bValue = b;
                        aValue = a;
                    }
                }
            }
            return aValue*bValue;
        }
        static List<int> PrimeNumber()
        {
            List<int> vs = new List<int>() { 2, 3, 5, 7 };
            int count = 4;
            int s = 9;

            for (s = 9; s < 135001; s += 2)//с шагом +=2 колличество проверок уменьшиться в 2 раза
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
