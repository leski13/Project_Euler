using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    class Program
    {
        //The prime factors of 13195 are 5, 7, 13 and 29.
        //What is the largest prime factor of the number 600851475143 ?
        
        static void Main(string[] args)
        {
            long x = Number(600851475143);
            Console.WriteLine(x);
            Console.ReadLine();
        }
        static long Number(long x)
        {
            List<int> vs = new List<int>();
            if (x >= 1)
            {
                for (int s = 2; s < x; s++)
                {
                    if (x % 2 == 0 || x % 3 == 0)
                    {
                        x = (x % 2 == 0) ? x / 2 : x / 3;
                        if (x % 2 == 0) vs.Add(2);
                        else vs.Add(3);
                        continue;
                    }
                    
                    if (s % 2 != 0 || s % 3 != 0)
                    {
                        if (x % s == 0)
                        {
                            x /= s;
                            vs.Add(s);
                        }
                    }
                }
                
            }
            vs.Add((int)x);
            foreach(var w in vs)
                Console.Write(w+ " ");
            Console.WriteLine();
            return x;
        }
    }
}
