using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem28
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculation());
            Console.ReadLine();
        }
        static int Calculation()
        {
            int sum = 1;
            int count = 1;
            for (int s = 3; s < 1002; s += 2)
            {

                int PVR = (int)(Math.Pow(s, 2));//правый верхний угол
                int LVR = PVR - 2 * count;//левый верхний угол
                int LNR = PVR - 4 * count;//левый нижний угол
                int PNR = PVR - 6 * count;//правый нижнмий угол
                sum += (PVR + LVR + LNR + PNR);
                count++;
            }
                
            return sum;
        }
    }
}
