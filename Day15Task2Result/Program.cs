using Day15Task1Solution;
using Shared.Helpers;
using System;

namespace Day15Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var droid = new TraversalDroid(Data.Program);
            droid.CreateMap();
            ConsoleHelper.PrintResult(droid.RenderMaze());
            ConsoleHelper.PrintResult(droid.TimeToFillWithOxygen());
        }
    }
}
