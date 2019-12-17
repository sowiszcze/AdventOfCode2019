using Day17Task1Solution;
using Shared.Helpers;
using System;
using System.Linq;

namespace Day17Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = VacuumRobot.Create(Data.Program);
            robot.Scan();
            ConsoleHelper.PrintResult(robot.Calibrate());
            ConsoleHelper.PrintResult(robot.RenderedMap.Split('\n').AsEnumerable());
        }
    }
}
