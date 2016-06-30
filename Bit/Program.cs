using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Bit
{
    class Program
    {
        static void Main(string[] args)
        {
            CounterGame();
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/counter-game
        /// кто последний взял палочку
        /// </summary>
        private static void CounterGame()
        {
            var t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                BigInteger n = BigInteger.Parse(Console.ReadLine());
                var richardWins = true; // luoise starts
                while (n != 1)
                {
                    BigInteger lessPowOf2 = 0;
                    for (BigInteger p = 1; lessPowOf2 == 0; p = p << 1)
                    {
                        if (p >= n)
                            lessPowOf2 = p >> 1;
                    }
                    if ((n & (n - 1)) == 0) // точная степень двух
                    {
                        n = lessPowOf2;
                    }
                    else
                    {
                        n -= lessPowOf2;
                    }
                    richardWins = !richardWins;
                }
                Console.WriteLine(richardWins ? "Richard" : "Louise");
            }
        }
    }
}
