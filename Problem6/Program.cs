using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6
{
    /*The sum of the squares of the first ten natural numbers is, 12+22+...+102=385
    The square of the sum of the first ten natural numbers is, (1+2+...+10)2=552=3025
    Hence the difference between the sum of the squares of the first ten natural numbers 
    and the square of the sum is 3025−385=2640.

    Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.*/

    delegate double Difference();
    class MyEvent
    {
        public event Difference Squares;

        public double OnSquares()
        {
            double res = 0;
            if (Squares != null)
            {
                res = Squares();
            }
            return res;
        }
    }

    class Program
    {
        static double Square()
        {
            double input = 1, pow=2;
            double outputSquares = 0;
            double outputSumSquares = 0;
            double output = 0;
            while (input < 101)
            {
                outputSquares += Math.Pow(input, pow);
                outputSumSquares += input;
                input++;
            }
            output = (Math.Pow(outputSumSquares, pow)) - outputSquares;
            return output;
        }

        static void Main(string[] args)
        {
            MyEvent evt = new MyEvent();
            evt.Squares += Square;

            Console.WriteLine(evt.OnSquares());
            Console.ReadLine();
        }

    }
}
