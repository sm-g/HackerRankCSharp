using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.ReadLine();
            //var A = Console.ReadLine().Split(new[] { ' ' }).Select(x => int.Parse(x)).ToList();
            //var B = Console.ReadLine().Split(new[] { ' ' }).Select(x => int.Parse(x)).ToList();

            var A = new[] { 1, 2, 3, 4, 5 }.ToList();
            var B = new[] { 1, 5, 2, 3, 7, 5 }.ToList();
            var n = A.Count;
            var m = B.Count;

            var L = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    L[i, j] = -1;
                }
            }

            Console.WriteLine(sub(A, B, 0, 0, L));
            Print(L);
            Console.Read();

        }

        private static void Print(int[,] L)
        {
            for (int i = 0; i < L.GetLength(0); i++)
            {
                for (int j = 0; j < L.GetLength(1); j++)
                {
                    Console.Write(L[i, j].ToString().PadLeft(3, ' '));
                }
                Console.WriteLine();
            }
        }

        static int sub(List<int> A, List<int> B, int i, int j, int[,] L)
        {
            if (i == A.Count - 1 || j == B.Count - 1)
                L[i, j] = 0;
            else if (A[i] == B[j])
                L[i, j] = 1 + sub(A, B, i + 1, j + 1, L);
            else
                L[i, j] = Math.Max(sub(A, B, i + 1, j, L), sub(A, B, i, j + 1, L));
            return L[i, j];
        }
    }
}
