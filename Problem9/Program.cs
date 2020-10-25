using System;   
using System.Collections.Generic;

/* Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

a2 + b2 = c2
For example, 3*3 + 4*4 = 9 + 16 = 25 = 52.

There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc.*/

namespace Problem9
{ 
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Compute();
            Console.WriteLine(PythagoreanTriple(input));
            Console.ReadLine();
        }
        //список с элементами, квадрат числа (<500)
        public static List<int> Compute()
        {
            List<int> output = new List<int>();
            for (int s = 2; s < 500; s++)
                output.Add(s * s);
            return output;
        }
        public static Tuple<int, int, int> PythagoreanTriple(List<int> vs)
        {
            int result = 1000;
            int count = vs.Count-1;
            int a = 1, b = 1, c=1;
            uint counter = 0; 
            for(int s = count; s > 1; s--)//a*b=C
            {
                for(int d = count - 1; d > 1; d--)//a*B=c
                {
                    counter++;//сколько раз выполнится поиск
                    int twoRes = vs[s] - vs[d];//A*b=c
                    
                    if (vs[s] > vs[d] * 2) break;
                    
                    if (vs.Contains(twoRes))
                    {
                        a = (int)Math.Sqrt(twoRes);
                        b = (int)Math.Sqrt(vs[d]);
                        c = (int)Math.Sqrt(vs[s]);
                        if (result - a - b - c == 0)
                        {
                            Console.WriteLine(counter);
                            Console.WriteLine(a * b * c);
                            return Tuple.Create(a, b, c);
                        }
                    }       
                }
            }
            return Tuple.Create(a, b, c);
        }
    }
}
