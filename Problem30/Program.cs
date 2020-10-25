using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem30
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(digitFifthPowers());
            Console.ReadLine();
        }

        static int digitFifthPowers()
        {
            List<int> output = new List<int>();
            for(int s = 10; s < 1000000; s++)
            {
                int input = Calculation(s);
                if (s == input) 
                    output.Add(s);
            }
            return output.Sum();
        }
        static int Calculation(int x)
        {
            int result = 0;
            while (x > 0)
            {
                result += (int)Math.Pow((x % 10), 5);
                x /= 10;
            }
            return result;
        }
    }
}
