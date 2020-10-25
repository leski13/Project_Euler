using System;

namespace Problem1
{
    /*If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. 
     * The sum of these multiples is 23. Find the sum of all the multiples of 3 or 5 below 1000.*/

    class Program
    {
        static void Main(string[] args)
        {
            int x = MultiLine(1000);
            Console.WriteLine(x);
            Console.ReadLine();
        }
        public static int MultiLine(int input)
        {
            int count = 0;
            for (int s = 0; s < input; s++)
            {
                if (s % 3 == 0 || s % 5 == 0)
                    count += s;
            }
            return count;
        }
    }
}
