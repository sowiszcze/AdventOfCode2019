using IntcodeInterpreter;
using Shared.Helpers;
using System;
using System.Linq;

namespace Day05Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpreter = new Interpreter(Data.Program);
            interpreter.AddInput(5);
            interpreter.Run();
            interpreter.AssureCompletion();
            if (interpreter.Output.Count > 1)
            {
                throw new Exception("Too many outputs.");
            }
            ConsoleHelper.PrintResult(interpreter.Output.Last());
        }
    }
}
