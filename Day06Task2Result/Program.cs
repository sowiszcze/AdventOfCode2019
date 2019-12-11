using Day06Task1Solution;
using Shared.Helpers;

namespace Day06Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.PrintResult(Solution.FindClosestPathLength(Data.Orbits, "YOU", "SAN"));
        }
    }
}
