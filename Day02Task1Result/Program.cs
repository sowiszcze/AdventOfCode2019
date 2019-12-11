using Day02Task1Solution;
using Shared.Helpers;

namespace Day02Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.PrintResult(Solution.Calculate(Solution.Fix(Data.Program, 12, 2)).GetResult());
        }
    }
}
