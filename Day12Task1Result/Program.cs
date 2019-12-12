using Day12Task1Solution;
using Shared.Helpers;
using System;

namespace Day12Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.PrintResult(Solution.CalculateEnergy(Data.Moons, 1000));
        }
    }
}
