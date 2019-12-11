using Day08Task1Solution;
using Shared.Helpers;

namespace Day08Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.PrintResult(Solution.GetResult(Data.Image, 25, 6, 0, 1, 2));
        }
    }
}
