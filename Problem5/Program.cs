using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5
{
    //2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    //What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SmallestMultiple());
            Console.ReadLine();
        }
        static int SmallestMultiple()
        {
            int output = 0, count=0;
            for(int s = 380; s < 1000000000; s+=380)
            {
                count++;
                if (s % 18 == 0 && s % 17 == 0 && s % 16 == 0 && s % 15 == 0 && s%14==0 && s % 13 == 0 && s % 12 == 0 && s % 11 == 0)
                {
                    output = s;                   
                    break;
                }
                
            }
            Console.WriteLine($"Count: {count}");
            return output;
        }
    }
}
