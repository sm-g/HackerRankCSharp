using NCalc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            var ops = new[] { "+", "-", "*", "/", "" };
            var strs = new List<string>();
            Console.WriteLine("start");
            var sw = Stopwatch.StartNew();
            strs = (from op0 in ops
                    from op1 in ops
                    from op2 in ops
                    from op3 in ops
                    from op4 in ops
                    from op5 in ops
                    from op6 in ops
                    from op7 in ops
                    where MaxEmpty(2, op0, op1, op2, op3, op4, op5, op6, op7) // трехзначные числа
                    select '1' + op0 + '2' + op1 + '3' + op2 + '4' + op3 + '5' + op4 + '6' + op5 + '7' + op6 + '8' + op7 + '9').AsParallel().ToList();

            // 78 solutions
            var m = (from s in strs
                     where new Expression(s).Evaluate().Equals(100)
                     select s + " = 100").AsParallel().ToList();
            sw.Stop();
            File.WriteAllLines("out.txt", m);

            Console.WriteLine("done in {0}", sw.Elapsed); // 28 sec
            Console.Read();
        }


        static bool MaxEmpty(int n, params string[] ops)
        {
            var high = ops.Count() - n - 1;
            var falseN = n + 1; // допустимо n пустых операторов подряд
            for (int i = 0; i < high; i++)
            {
                var one = ops.Skip(i).Take(falseN).Distinct();
                if (one.Count() == 1 && one.First() == string.Empty)
                    return false;
            }

            return true;
        }
    }
}
