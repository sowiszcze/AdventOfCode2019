using Day07Task1Solution;
using Shared.Helpers;

namespace Day07Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.PrintResult(Solution.FindBestSettings(Data.Program, 0, 0, 4));
        }
    }
}
