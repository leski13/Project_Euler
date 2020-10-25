using System;
using System.Collections.Generic;

/*If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters 
 * used in total.
If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?*/

namespace Problems17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumberLetterCounts());
            Console.ReadLine();
        }
        static int NumberLetterCounts()
        {
            int output = 0;
            Dictionary<int, int> letterCount = new Dictionary<int, int> 
            {
                {1,3},{2,3},{3,5},{4,4},{5,4},{6,3},{7,5},{8,5},{9,4},{10,3},
                {11,6},{12,6},{13,8},{14,8},{15,7},{16,7},{17,9},{18,8},{19,8},{20,6},
                {30,6},{40,5},{50,5},{60,5},{70,7},{80,6},{90,6},{100,7},{1000,11}
            };
            
            for(int s = 1; s < 100; s++)
            {                
                if (s>20 && !letterCount.ContainsKey(s))
                {
                    int d = s % 10;
                    int x = s-d;
                    output += letterCount[x] + letterCount[d];
                    continue;
                }
                output += letterCount[s];
            }
            output *= 10;//от 1 до 99(включительно) повторяется 10 раз
            for(byte w = 1; w < 10; w++)
            {
                int hundred = 0;
                int res = 0;
                byte hundredLetter = 7;
                res = letterCount[w] + hundredLetter;
                hundred = (res + 3) * 99 + res;
                output += hundred;
            }
            
            return output+letterCount[1000];
        }
    }
}
