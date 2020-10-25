using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7
{
    /*By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
    What is the 10 001st prime number?*/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PrimeNumber());
            Console.ReadLine();
        }
        
        public static int PrimeNumber()
        {
            List<int> vs = new List<int>() { 2, 3, 5, 7 };
            int count = 4;
            int s = 9;
            
                for (s = 9; s<135001; s += 2)//с шагом +=2 колличество проверок уменьшиться в 2 раза
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
            
            return vs.ElementAt(10000);
        }
    }
}
