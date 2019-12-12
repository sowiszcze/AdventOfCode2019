using Day12Task1Solution;
using Shared.Helpers;
using System;

namespace Day12Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.PrintResult(Solution.CalculateLoopSteps(Data.Moons));
        }
    }
}
