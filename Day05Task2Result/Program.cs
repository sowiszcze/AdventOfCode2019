using Day05Task1Solution;
using Shared.Helpers;
using System;
using System.Linq;

namespace Day05Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Solution.Run(Data.Program, 5);
            if (result.Count > 1)
            {
                throw new Exception("Too many outputs.");
            }
            ConsoleHelper.PrintResult(result.Last());
        }
    }
}
