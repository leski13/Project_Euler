using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

3
7 4
2 4 6
8 5 9 3
That is, 3 + 7 + 4 + 9 = 23.

Find the maximum total from top to bottom of the triangle below:*/
namespace Problems18
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[][] input = new byte[15][];
            input[0] = new byte[] { 75 };
            input[1] = new byte[] { 95,64 };
            input[2] = new byte[] { 17,47,82 };
            input[3] = new byte[] { 18,35,87,10 };
            input[4] = new byte[] { 20,04,82,47,65 };
            input[5] = new byte[] { 19,01,23,75,03,34 };
            input[6] = new byte[] { 88,02,77,73,07,63,67 };
            input[7] = new byte[] { 99,65,04,28,06,16,70,92 };
            input[8] = new byte[] { 41,41,26,56,83,40,80,70,33 };
            input[9] = new byte[] { 41,48,72,33,47,32,37,16,94,29 };
            input[10] = new byte[] { 53,71,44,65,25,43,91,52,97,51,14 };
            input[11] = new byte[] { 70,11,33,28,77,73,17,78,39,68,17,57 };
            input[12] = new byte[] { 91,71,52,38,17,14,91,43,58,50,27,29,48 };
            input[13] = new byte[] { 63,66,04,68,89,53,67,30,73,16,69,87,40,31 };
            input[14] = new byte[] { 04,62,98,27,23,09,70,98,73,93,38,53,60,04,23 };
            Console.WriteLine(MaximumPathSum(input));
            Console.ReadLine();
        }
        static int MaximumPathSum(byte[][] input)
        {
            int output = input[0][0];
            int x = 0;
            List<int> result = new List<int>();
            for(byte s = 0; s < input.Length-2; s++)
            {
                for(byte d = 0; d < input[s].Length; )
                {
                    int prevPrev = 0, nextPrev = 0;//число 95
                    int prevNext = 0, nextNext = 0;//число 64
                    int prev = 0, next = 0;
                    output -= input[s][x];//при вычислении это число суммируется по 2 раза
                    prevPrev = input[s][x] + input[s+1][x] + input[s+2][x];
                    nextPrev = input[s][x] + input[s+1][x] + input[s+2][x+1];
                    prev = (prevPrev > nextPrev) ? prevPrev : nextPrev;
                    prevNext = input[s][x] + input[s+1][x+1] + input[s+2][x+1];
                    nextNext = input[s][x] + input[s+1][x+1] + input[s+2][x+2];
                    next = (prevNext > nextNext) ? prevNext : nextNext;

                    if (nextNext > prevNext && nextNext>prevPrev && nextNext>nextPrev) x += 2;//устанавливаю Х
                    else if (prevPrev > nextPrev && prevPrev>prevNext && prevPrev>nextNext) x +=0;
                    else x++;

                    output += (prev > next) ? prev : next;
                    s++;//устанавливаю S
                    break;       
                }
            }
            return output;
        }
    }
}
