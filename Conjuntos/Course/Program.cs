using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> courseA = new HashSet<int>();
            Console.Write("How many students for course A: ");
            int a = int.Parse(Console.ReadLine());
            for (int i = 1; i <= a; i++)
            {
                Console.Write($"{i}:");
                courseA.Add(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine();
            HashSet<int> courseB = new HashSet<int>();
            Console.Write("How many students for course B: ");
            int b = int.Parse(Console.ReadLine());
            for (int i = 1; i <= b; i++)
            {
                Console.Write($"{i}:");
                courseB.Add(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine();
            HashSet<int> courseC = new HashSet<int>();
            Console.Write("How many students for course C: ");
            int c = int.Parse(Console.ReadLine());
            for (int i = 1; i <= c; i++)
            {
                Console.Write($"{i}:");
                courseC.Add(int.Parse(Console.ReadLine()));
            }

            HashSet<int> courseD = new HashSet<int>();
            courseA.UnionWith(courseB);
            courseA.UnionWith(courseC);

            Console.WriteLine("Total students: " + courseA.Count);
        }
    }
}
