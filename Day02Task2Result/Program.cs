using Day02Task1Solution;
using Shared.Helpers;
using System;

namespace Day02Task2Result
{
    class Program
    {
        private const int ExpectedOutput = 19690720;

        static void Main(string[] args)
        {
            int output;

            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    output = Solution.Calculate(Solution.Fix(Data.Program, noun, verb)).GetResult();

                    if (output == ExpectedOutput)
                    {
                        ConsoleHelper.PrintResult(100 * noun + verb);

                        return;
                    }
                }
            }

            Console.WriteLine("No result. Something went wrong!");
        }
    }
}
