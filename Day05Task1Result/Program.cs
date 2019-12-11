using IntcodeInterpreter;
using Shared.Helpers;
using System;
using System.Linq;

namespace Day05Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpreter = new Interpreter(Data.Program);
            var result = interpreter.RunToCompletion(1);
            if (result.Take(result.Count - 1).Any(r => r != 0))
            {
                throw new Exception("Not all tests passed.");
            }
            ConsoleHelper.PrintResult(result.Last());
        }
    }
}
