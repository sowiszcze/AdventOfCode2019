using Day02Task1Solution;
using IntcodeInterpreter;
using Shared.Helpers;
using System;

namespace Day02Task2Result
{
    class Program
    {
        private const int ExpectedOutput = 19690720;

        static void Main(string[] args)
        {
            long output;

            for (long noun = 0; noun < 100; noun++)
            {
                for (long verb = 0; verb < 100; verb++)
                {
                    var interpreter = new Interpreter(Solution.Fix(Data.Program, noun, verb));
                    interpreter.Run();
                    interpreter.AssureCompletion();
                    output = interpreter.Memory[0];

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
