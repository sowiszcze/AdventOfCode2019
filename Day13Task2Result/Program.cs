using Day13Task1Solution;
using Shared.Helpers;

namespace Day13Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.PrintResult(Solution.Simulate(Solution.Crack(Data.Program)));
        }
    }
}
