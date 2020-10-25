using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    /*A palindromic number reads the same both ways.The largest palindrome made from the product of two 2-digit 
      numbers is 9009 = 91 × 99.     Find the largest palindrome made from the product of two 3-digit numbers.*/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Palindrome());
            Console.ReadLine();
        }
        static int Palindrome()
        {
            int output = 0;

            for (int s=999; s > 1; s--)
            {
                for(int d = 999; d > 1; d--)
                {
                    int result = s * d;
                    int reverse = Reverse(result);
                    if (result == reverse)
                    {
                        output = (output > result) ? output : result;                        
                        break;
                    }                
                }
            }
            return output;
        }
        static int Reverse(int res)
        {
            List<byte> vs = new List<byte>();
            string str = "";
            while (res > 0)
            {
                byte single = (byte)(res % 10);
                vs.Add(single);
                res /= 10;
            }

            for (int s = 0; s < vs.Count; s++)
                str += vs[s];

            res = Convert.ToInt32(str);
            return res;
        }
    }
}
