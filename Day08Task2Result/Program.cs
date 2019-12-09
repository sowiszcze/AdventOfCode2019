using Day08Task1Solution;
using System;

namespace Day08Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var line in Solution.RenderImage(Solution.FlattenImage(Solution.CreateImage(Data.Image, 25, 6))))
            {
                Console.WriteLine(line);
            }
        }
    }
}
