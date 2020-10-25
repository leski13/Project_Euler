using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*The following iterative sequence is defined for the set of positive integers:

n → n/2 (n is even)
n → 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:

13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million.*/

namespace Problem14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(longestCollatzSequence());
            Console.ReadLine();
        }
        static uint longestCollatzSequence()
        {
            uint x = 0;
            uint res = 0;
            uint count = 0;
            uint output = 0;
            Dictionary<uint, uint> input = new Dictionary<uint, uint>();
            for(uint s = 1; s < 1000000; s++)
            {
                x = s;
                while(x != 1)
                {
                    x=Computation(x);
                    count++;
                    if (x < s)
                    {
                        count += input[x];
                        break;
                    }
                }
  
                input.Add(s, count);
                if (count > output) res = s;
                output = (output > count) ? output : count;            
                count = 0;
            }
            
            return res;
        }
        static uint Even(uint n) => n /= 2;//четные

        static uint Odd(uint n) => (3*n) + 1;//не четные

        static uint Computation(uint n)=>  (n % 2 == 0) ? Even(n) : Odd(n);

    }
}
