using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1p, 2p, 5p, 10p, 20p, 50p, £1 (100p), and £2 (200p).
namespace Problem31
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        static int coinSums()
        {
            List<int> nums = new List<int>{ 1, 2, 5, 10, 20, 50, 100, 200 };
            /*
             *      1       2       5       10      20      50      100     200
             *  1   1       1       1       1       1       1       1       1
             *  2   170     51      42      13      4       1       0       0
             *  3   
             *  4
             *  5
             *  6
             *  7
             *  8   0       0       0       0       0       0       0       0
             */
            //1 монета - 1 каунт
            //2 монеты - 200(при 1: 200/ на значение второй монеты и минус 1(см. 1 монета))(99,39,19,9,3,1)=170
            //              при 2 и 5: 200/5 и /2 (19) 19+19+9+3+1=51
            //              при 2 и остальное: 200/значение второй монеты и минус 1(см. 1 монета)(19,9,3,1)
            //              стальные монеты алгоритм повторяется
            //
            //3 монеты
            int count = 0;

            return count;
        }
    }
}
