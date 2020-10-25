using System;
/*Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, 
 * there are exactly 6 routes to the bottom right corner.
 How many such routes are there through a 20×20 grid?*/

namespace Problems15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LatticePaths());
            Console.ReadLine();
        }
        static long LatticePaths()
        {
            long output = 1;
            const int gridSize = 20;
            for(int s = 0; s < gridSize; s++)
            {
                output *= (2 * gridSize)-s;
                output /= s + 1;
            }

            return output;
        }
    }
}
