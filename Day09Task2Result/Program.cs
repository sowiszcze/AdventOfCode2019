using IntcodeInterpreter;
using Shared.Helpers;
using System.Linq;

namespace Day09Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpreter = new Interpreter(Data.Program);
            interpreter.AddInput(2);
            interpreter.Run();
            interpreter.AssureCompletion();
            ConsoleHelper.PrintResult(interpreter.Output.Last());
        }
    }
}
