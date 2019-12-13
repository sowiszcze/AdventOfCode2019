using Day13Task1Solution;
using Shared.Helpers;
using System;

namespace Day13Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.PrintResult(Solution.CountBlocks(Solution.Build(Data.Program)));
        }
    }
}
