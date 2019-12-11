using Day04Task1Solution;
using Shared.Helpers;

namespace Day04Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.PrintResult(Solution.CountValidCodes(Data.Lower, Data.Upper));
        }
    }
}