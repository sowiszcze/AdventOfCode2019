using Day02Task1Solution;
using System;

namespace Day02Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The result is: {Solution.Calculate(Solution.Fix(Data.Program)).GetResult()}");
        }
    }
}
