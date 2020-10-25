using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*You are given the following information, but you may prefer to do some research for yourself.

1 Jan 1900 was a Monday.
1 Jan 1901 was a Вторник(2).
31 28(9) 31 30 31 30 31 31 30 31 30 31
A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
How many Sundays(7) fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?*/
namespace Problems19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountingSundays());
            Console.ReadLine();
        }
        static int CountingSundays()
        {
            List<int> month = new List<int>() { 31,28,31,30,31,30,31,31,30,31,30,31};
            int output = 0;
            int result = 2;//потому что 1.01.1901 - вторник
            for(int s = 1; s < 101; s++)
            {
                month[1] = (s % 4 == 0) ? 29 : 28;
                for(int d = 0; d < 12; d++)
                {
                    result =(result + month[d])%7;
                    if (result == 0) output++;
                }
            }
            return output;
        }
    }
}
