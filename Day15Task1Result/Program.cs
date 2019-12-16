using Day15Task1Solution;
using Shared.Helpers;
using System;

namespace Day15Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var droid = new RepairDroid(Data.Program);
            ConsoleHelper.PrintResult(droid.FindRouteToOxygenSystem());
        }
    }
}
