using Day14Task1Solution;
using Shared.Helpers;
using System;

namespace Day14Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Solution(Data.Recipes);
            engine.CalculateNeedsFor("FUEL", 1, "NONE");
            ConsoleHelper.PrintResult(engine.GetNeedsOf("ORE"));
        }
    }
}
