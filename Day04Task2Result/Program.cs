using Day04Task2Solution;
using Shared.Helpers;

namespace Day04Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.PrintResult(Solution.CountValidCodes(Data.Lower, Data.Upper));
        }
    }
}
