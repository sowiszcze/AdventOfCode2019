using Day11Task1Solution;
using Day11Task1Solution.Enums;
using Shared.Constants;
using Shared.Helpers;
using System;

namespace Day11Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.PrintResult(ConsoleHelper.Render(Solution.RunRobot(Data.Program, Color.White).Render(), CharacterMaps.Bit));
        }
    }
}
