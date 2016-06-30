using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warmup
{
    class Program
    {
        static void Main(string[] args)
        {
            AngryChildren();

            Console.Read();


        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/angry-children
        /// </summary>
        private static void AngryChildren()
        {
            var n = int.Parse(Console.ReadLine());
            var x = new List<Int64>(n);
            var k = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                x.Add(Int64.Parse(Console.ReadLine()));
            }
            x.Sort();
            Int64 min = Int64.MaxValue;
            for (int i = 0; i <= n - k; i++)
            {
                min = Math.Min(min, x[i + k - 1] - x[i]);
            }
            Console.WriteLine(min);
        }

        private static void LoveLetterMystery()
        {
            var t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int ops = 0;
                var chars = Console.ReadLine().ToCharArray();
                for (int x = 0; x < chars.Length / 2; x++)
                {
                    var endX = chars.Length - x - 1;
                    var biggerX = chars[x] > chars[endX] ? x : endX;
                    while (chars[x] != chars[endX])
                    {
                        chars[biggerX]--;
                        ops++;
                    }
                }

                Console.WriteLine(ops);
            }
        }
    }
}
