using Day05Task1Solution;
using System;
using System.Linq;

namespace Day09Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Solution.Run(Data.Program, 2L);
            Console.WriteLine($"The result is: {result.Last()}");
        }
    }
}
