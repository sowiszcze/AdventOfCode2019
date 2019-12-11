using Day05Task1Solution;
using Shared.Helpers;
using System.Linq;

namespace Day09Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Solution.Run(Data.Program, 1L);
            ConsoleHelper.PrintResult(result.Last());
        }
    }
}
