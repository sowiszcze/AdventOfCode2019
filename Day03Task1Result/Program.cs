using Day03Task1Solution;
using Shared.Helpers;

namespace Day03Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands1 = Solution.CreateCommandsList(Data.Wire1);
            var commands2 = Solution.CreateCommandsList(Data.Wire2);
            var path1 = Solution.CreatePaths(commands1);
            var path2 = Solution.CreatePaths(commands2);
            ConsoleHelper.PrintResult(Solution.FindIntersections(path1, path2).FindClosest().GetDistance());
        }
    }
}
