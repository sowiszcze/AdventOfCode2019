using Day18Task1Solution;
using Shared.Helpers;
using System;

namespace Day18Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var vault = new VaultLighter(Data.Tunnels);
            ConsoleHelper.PrintResult(vault.FindMinimumStepsForAllKeys());
        }
    }
}
