using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
/*A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. 
 * If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:

012   021   102   120   201   210

What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?*/
namespace Problem24
{
    class Program
    {
        const int numberPosition = 1_000_000;

        static void Main(string[] args)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            Console.WriteLine(lexicographicPermutations());
            st.Stop();
            Console.WriteLine(st.Elapsed);
            Console.ReadLine();
        }
        static uint lexicographicPermutations()
        {
            List<ulong> output = new List<ulong>();
            uint result = 0;
            int numberCombination = Factorial(10);
            var numberComputation = Number(0, numberCombination);
            int loc = numberPosition - numberComputation.Item1;
            for (ulong s = numberComputation.Item3; s < numberComputation.Item4; s++)
            {
                if(output.Count < loc)
                {
                    string number = s.ToString();
                    if (number.GroupBy(x => x).Count() == 10)
                        output.Add(s);
                }
            }
            result = (uint)(output[loc-1]);
            return result;
        }
        private static int Factorial(int x)//количество подходящих вариантов
        {
            int result = 1;
            if (x == 1) return result;
            result = x * Factorial(x-1);
            return result;
        }
        
        private static Tuple<int, int, ulong, ulong> Number(int start, int end)
        {
            ulong startNumber = 0;
            ulong endNumber = 0;
            int position = 1_000_000;
            int nine = (int)(Factorial(9)/9);
            start = start - nine;//исключаю повторения 00
            for (ulong s = 0; s < 10_000_000_000; s+=100_000_000)
            {
                if (s % 11 == 0 && s!=0) continue;//исключаю повторения 11 и 22
                if ((start+nine) > position)
                {
                    startNumber = s;
                    break;
                }
                start += nine;
            }
            for (ulong x = 10_000_000_000; x > 1; x -= 100_000_000)
            {
                if (x % 11 == 0 && x!=0) continue;
                if ((end-nine) < position)
                {
                    endNumber = x;
                    break;
                }
                end -= nine;
            }
            return Tuple.Create(start, end, startNumber, endNumber);
        }
    }
}
