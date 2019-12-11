using Day11Task1Solution;
using Day11Task1Solution.Enums;
using Shared.Helpers;

namespace Day11Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.PrintResult(Solution.RunRobot(Data.Program, Color.Black).TotalPainted);
        }
    }
}
