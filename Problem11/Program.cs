using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

//In the 20×20 grid below, four numbers along a diagonal line have been marked in red.
//The product of these numbers is 26 × 63 × 78 × 14 = 1788696.
//What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the grid?

namespace Problem11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Product());
            Console.ReadLine();
        }

        static int Product()
        {
            byte basis = 1;
            int output = 1;
            int horizontal = 1, vertical = 1, diagonal = 1;
            byte[,] input = new byte[20, 20] 
            { 
                { 08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08 },
                { 49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00 },
                { 81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65 },
                { 52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91 },
                { 22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80 },
                { 24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50 },
                { 32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70 },
                { 67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21 },
                { 24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72 },
                { 21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95 },
                { 78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92 },
                { 16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57 },
                { 86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58 },
                { 19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40 },
                { 04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66 },
                { 88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69 },
                { 04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36 },
                { 20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16 },
                { 20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54 },
                { 01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48 }
            };

            for(byte s = 0; s < 20; s++)
            {
                for(byte d = 0; d < 20; d++)
                {
                    if (input[s, d] > 80)
                    {
                        horizontal = Horizontal(s, d, input, basis);
                        output = (output > horizontal) ? output : horizontal;
                        vertical = Vertical(s, d, input, basis);
                        output = (output > vertical) ? output : vertical;
                        diagonal = Diagonal(s, d, input, basis);
                        output = (output > diagonal) ? output : diagonal;

                        basis = Planka(output);//нижняя граница
                    }
                }
            }

            Console.WriteLine();
            return output;
        }

        private static int Vertical(byte s, byte d, byte[,] input, byte basis)
        {
            List<byte> mini = new List<byte>();
            int max = 0;
            int output = 1;

            int val = (s > 3 && s < 17) ? 3 : s;
            switch (val)
            {
                case 0:
                    mini.Add(input[s, d]);
                    mini.Add(input[s+1, d]);
                    mini.Add(input[s+2, d]);
                    mini.Add(input[s+3, d]);
                    break;
                case 1:
                    mini.Add(input[s-1, d]);
                    mini.Add(input[s, d]);
                    mini.Add(input[s+1, d]);
                    mini.Add(input[s+2, d]);
                    mini.Add(input[s+3, d]);
                    break;
                case 2:
                    mini.Add(input[s-2, d]);
                    mini.Add(input[s-1, d]);
                    mini.Add(input[s, d]);
                    mini.Add(input[s+1, d]);
                    mini.Add(input[s+2, d]);
                    mini.Add(input[s+3, d]);
                    break;
                case 3:
                    mini.Add(input[s-3, d]);
                    mini.Add(input[s-2, d]);
                    mini.Add(input[s-1, d]);
                    mini.Add(input[s, d]);
                    mini.Add(input[s+1, d]);
                    mini.Add(input[s+2, d]);
                    mini.Add(input[s+3, d]);
                    break;
                case 17:
                    mini.Add(input[s-3, d]);
                    mini.Add(input[s-2, d]);
                    mini.Add(input[s-1, d]);
                    mini.Add(input[s, d]);
                    mini.Add(input[s+1, d]);
                    mini.Add(input[s+2, d]);
                    break;
                case 18:
                    mini.Add(input[s-3, d]);
                    mini.Add(input[s-2, d]);
                    mini.Add(input[s-1, d]);
                    mini.Add(input[s, d]);
                    mini.Add(input[s+1, d]);
                    break;
                case 19:
                    mini.Add(input[s-3, d]);
                    mini.Add(input[s-2, d]);
                    mini.Add(input[s-1, d]);
                    mini.Add(input[s, d]);
                    break;
            }
            for (byte w = 0; w < mini.Count - 3; w++)
            {
                if (mini[w]<basis) continue;
                max = mini[w] * mini[w + 1] * mini[w + 2] * mini[w + 3];
                output = (output > max) ? output : max;
                max = 0;
            }
            mini.Clear();
            return output;
        }

        private static int Diagonal(byte s, byte d, byte[,] input, byte basis)
        {
            List<byte> mini = new List<byte>();
            List<byte> miniR = new List<byte>();
            int max = 0;
            int diag = 0;
            int output = 1;

            try
            {
                int val = (s > 3 && s < 17) ? 3 : s;
                switch (val)
                {
                    case 0:
                        if (d < 3)
                        {
                            miniR.Add(input[s, d]);
                            miniR.Add(input[s + 1, d + 1]);
                            miniR.Add(input[s + 2, d + 2]);
                            miniR.Add(input[s + 3, d + 3]);
                            break;
                        }
                        if (d > 17)
                        {
                            mini.Add(input[s, d]);
                            mini.Add(input[s + 1, d - 1]);
                            mini.Add(input[s + 2, d - 2]);
                            mini.Add(input[s + 3, d - 3]);
                            break;
                        }

                        mini.Add(input[s, d]);
                        mini.Add(input[s + 1, d - 1]);
                        mini.Add(input[s + 2, d - 2]);
                        mini.Add(input[s + 3, d - 3]);

                        miniR.Add(input[s, d]);
                        miniR.Add(input[s + 1, d + 1]);
                        miniR.Add(input[s + 2, d + 2]);
                        miniR.Add(input[s + 3, d + 3]);
                        break;
                    case 1:
                        mini.Add(input[s - 1, d - 1]);
                        mini.Add(input[s, d]);
                        mini.Add(input[s + 1, d + 1]);
                        mini.Add(input[s + 2, d + 2]);
                        mini.Add(input[s + 3, d + 3]);

                        miniR.Add(input[s - 1, d + 1]);
                        miniR.Add(input[s, d]);
                        miniR.Add(input[s + 1, d - 1]);
                        miniR.Add(input[s + 2, d - 2]);
                        miniR.Add(input[s + 3, d - 3]);
                        break;
                    case 2:
                        mini.Add(input[s - 2, d + 2]);
                        mini.Add(input[s - 1, d + 1]);
                        mini.Add(input[s, d]);
                        mini.Add(input[s + 1, d - 1]);
                        mini.Add(input[s + 2, d - 2]);
                        mini.Add(input[s + 3, d - 3]);

                        miniR.Add(input[s - 2, d - 2]);
                        miniR.Add(input[s - 1, d - 1]);
                        miniR.Add(input[s, d]);
                        miniR.Add(input[s + 1, d + 1]);
                        miniR.Add(input[s + 2, d + 2]);
                        miniR.Add(input[s + 3, d + 3]);
                        break;
                    case 3:
                        mini.Add(input[s - 3, d - 3]);
                        mini.Add(input[s - 2, d - 2]);
                        mini.Add(input[s - 1, d - 1]);
                        mini.Add(input[s, d]);
                        mini.Add(input[s + 1, d + 1]);
                        mini.Add(input[s + 2, d + 2]);
                        mini.Add(input[s + 3, d + 3]);

                        miniR.Add(input[s - 3, d + 3]);
                        miniR.Add(input[s - 2, d + 2]);
                        miniR.Add(input[s - 1, d + 1]);
                        miniR.Add(input[s, d]);
                        miniR.Add(input[s + 1, d - 1]);
                        miniR.Add(input[s + 2, d - 2]);
                        miniR.Add(input[s + 3, d - 3]);
                        break;
                    case 17:
                        mini.Add(input[s - 3, d - 3]);
                        mini.Add(input[s - 2, d - 2]);
                        mini.Add(input[s - 1, d - 1]);
                        mini.Add(input[s, d]);
                        mini.Add(input[s + 1, d + 1]);
                        mini.Add(input[s + 2, d + 2]);

                        miniR.Add(input[s - 3, d + 3]);
                        miniR.Add(input[s - 2, d + 2]);
                        miniR.Add(input[s - 1, d + 1]);
                        miniR.Add(input[s, d]);
                        miniR.Add(input[s + 1, d - 1]);
                        miniR.Add(input[s + 2, d - 2]);
                        break;
                    case 18:
                        mini.Add(input[s - 3, d - 3]);
                        mini.Add(input[s - 2, d - 2]);
                        mini.Add(input[s - 1, d - 1]);
                        mini.Add(input[s, d]);
                        mini.Add(input[s + 1, d + 1]);

                        miniR.Add(input[s - 3, d + 3]);
                        miniR.Add(input[s - 2, d + 2]);
                        miniR.Add(input[s - 1, d + 1]);
                        miniR.Add(input[s, d]);
                        miniR.Add(input[s + 1, d - 1]);
                        break;
                    case 19:
                        mini.Add(input[s - 3, d - 3]);
                        mini.Add(input[s - 2, d - 2]);
                        mini.Add(input[s - 1, d - 1]);
                        mini.Add(input[s, d]);

                        miniR.Add(input[s - 3, d + 3]);
                        miniR.Add(input[s - 2, d + 2]);
                        miniR.Add(input[s - 1, d + 1]);
                        miniR.Add(input[s, d]);
                        break;
                }
            }
            catch
            {

            }
            for (byte w = 0; w < mini.Count - 3; w++)
            {
                try
                {
                    if (mini[w] < basis) continue;
                    max = (mini.Count < 4) ? 0 : mini[w] * mini[w + 1] * mini[w + 2] * mini[w + 3];
                    if (miniR[w] < basis) continue;
                    diag = (miniR.Count < 4) ? 0 : miniR[w] * miniR[w + 1] * miniR[w + 2] * miniR[w + 3];
                }
                catch
                {

                }
                finally
                {
                    if (max > diag)
                        output = (output > max) ? output : max;
                    else
                        output = (output > diag) ? output : diag;
                    max = 0;
                    diag = 0;
                }
            }
            mini.Clear();
            miniR.Clear();
            return output;
        }

        static byte Planka(int input) => (byte)(input / 99 / 99 / 99);
        
        static int Horizontal(byte s, byte d, byte[,] input, byte basis)
        {
            List<byte> mini = new List<byte>();
            int max = 0;
            int output = 1;

            int val = (d > 3 && d < 17) ? 3 : d;
            switch (val)
            {
                case 0:
                    mini.Add(input[s, d]);
                    mini.Add(input[s, d + 1]);
                    mini.Add(input[s, d + 2]);
                    mini.Add(input[s, d + 3]);
                    break;
                case 1:
                    mini.Add(input[s, d - 1]);
                    mini.Add(input[s, d]);
                    mini.Add(input[s, d + 1]);
                    mini.Add(input[s, d + 2]);
                    mini.Add(input[s, d + 3]);

                    break;
                case 2:
                    mini.Add(input[s, d - 2]);
                    mini.Add(input[s, d - 1]);
                    mini.Add(input[s, d]);
                    mini.Add(input[s, d + 1]);
                    mini.Add(input[s, d + 2]);
                    mini.Add(input[s, d + 3]);
                    break;
                case 3:
                    mini.Add(input[s, d - 3]);
                    mini.Add(input[s, d - 2]);
                    mini.Add(input[s, d - 1]);
                    mini.Add(input[s, d]);
                    mini.Add(input[s, d + 1]);
                    mini.Add(input[s, d + 2]);
                    mini.Add(input[s, d + 3]);
                    break;
                case 17:
                    mini.Add(input[s, d - 3]);
                    mini.Add(input[s, d - 2]);
                    mini.Add(input[s, d - 1]);
                    mini.Add(input[s, d]);
                    mini.Add(input[s, d + 1]);
                    mini.Add(input[s, d + 2]);
                    break;
                case 18:
                    mini.Add(input[s, d - 3]);
                    mini.Add(input[s, d - 2]);
                    mini.Add(input[s, d - 1]);
                    mini.Add(input[s, d]);
                    mini.Add(input[s, d + 1]);
                    break;
                case 19:
                    mini.Add(input[s, d - 3]);
                    mini.Add(input[s, d - 2]);
                    mini.Add(input[s, d - 1]);
                    mini.Add(input[s, d]);
                    break;
            }
            for (byte w = 0; w < mini.Count - 3; w++)
            {
                if (mini[w]<basis) continue;
                max = mini[w] * mini[w + 1] * mini[w + 2] * mini[w + 3];
                output = (output > max) ? output : max;
                max = 0;
            }
            mini.Clear();
            return output;
        }
    }
}
