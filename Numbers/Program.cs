using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Reverse();
            Console.Read();
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/reverse-game
        /// </summary>
        private static void Reverse()
        {
            var t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                var strs = Console.ReadLine().Split(new[] { ' ' });
                var n = int.Parse(strs[0]);
                var k = int.Parse(strs[1]);
                Console.WriteLine(k < n / 2 ? (k + 1) * 2 - 1 : (n - k - 1) * 2);
            }
        }
    }
}
