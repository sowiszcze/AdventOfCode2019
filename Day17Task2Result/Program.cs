using Day17Task1Solution;
using Shared.Helpers;
using System;

namespace Day17Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = VacuumRobot.CreateHacked(Data.Program);
            ConsoleHelper.PrintResult(robot.Broadcast(Data.Commands));
        }
    }
}
