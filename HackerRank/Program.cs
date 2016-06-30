using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            MissingNumbers();
            Console.Read();
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/missing-numbers
        /// </summary>
        private static void MissingNumbers()
        {
            var n = int.Parse(Console.ReadLine());
            var A = Console.ReadLine().Split(new[] { ' ' }).Select(x => int.Parse(x)).ToList();
            var aDict = new Dictionary<int, int>();
            var m = int.Parse(Console.ReadLine());
            var B = Console.ReadLine().Split(new[] { ' ' }).Select(x => int.Parse(x)).ToList();
            var bDict = new Dictionary<int, int>();
            foreach (var item in A)
            {
                if (aDict.Keys.Contains(item))
                    aDict[item]++;
                else
                    aDict[item] = 1;
            } 
            foreach (var item in B)
            {
                if (bDict.Keys.Contains(item))
                    bDict[item]++;
                else
                    bDict[item] = 1;
            }

            foreach (var item in bDict.Keys.ToList())
            {
                int s = 0;
                aDict.TryGetValue(item, out s);
                bDict[item] -= s;
            }

            foreach (var item in bDict.Keys.Where(k => bDict[k] > 0).OrderBy(i => i))
            {
                Console.Write(String.Format("{0} ", item));
            }
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/closest-numbers
        /// </summary>
        private static void ClosetNumbers()
        {
            var n = int.Parse(Console.ReadLine());
            var nums = Console.ReadLine().Split(new[] { ' ' }).Select(x => int.Parse(x)).ToList();
            nums.Sort();
            var minIndexes = new List<int>();
            var minDif = int.MaxValue;
            for (int i = 1; i < n; i++)
            {
                if (nums[i] - nums[i - 1] <= minDif)
                {
                    if (nums[i] - nums[i - 1] == minDif)
                        minIndexes.Add(i - 1);
                    else
                    {
                        minDif = nums[i] - nums[i - 1];
                        minIndexes = new List<int> { i - 1 };
                    }
                }
            }
            minIndexes.ForEach(i => Console.Write(String.Format("{0} {1} ", nums[i], nums[i + 1])));
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/the-grid-search
        /// подмассив символов
        /// </summary>
        private static void GridSearch()
        {
            var tests = int.Parse(Console.ReadLine());
            for (int t = 0; t < tests; t++)
            {
                // big grid
                var RC = Console.ReadLine().Split(new[] { ' ' }).Select(x => int.Parse(x)).ToList();

                var G = new string[RC[0]];
                for (int r = 0; r < RC[0]; r++)
                {
                    G[r] = Console.ReadLine();
                }

                // pattern
                var rc = Console.ReadLine().Split(new[] { ' ' }).Select(x => int.Parse(x)).ToList();
                var P = new string[rc[0]];
                for (int r = 0; r < rc[0]; r++)
                {
                    P[r] = Console.ReadLine();
                }

                var found = false;
                for (int i = 0; i <= RC[0] - rc[0] && !found; i++)
                {
                    var first = G[i].IndexOf(P[0]);
                    if (first != -1)
                    {
                        found = true;
                        for (int j = 1; j < rc[0] && found; j++)
                        {
                            found &= G[i + j].Substring(first, rc[1]) == P[j];
                        }
                    }
                }
                if (found)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }

    }
}
