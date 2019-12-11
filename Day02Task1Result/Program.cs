using Day02Task1Solution;
using IntcodeInterpreter;
using Shared.Helpers;

namespace Day02Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpreter = new Interpreter(Solution.Fix(Data.Program, 12, 2));
            interpreter.Run();
            interpreter.AssureCompletion();
            ConsoleHelper.PrintResult(interpreter.Memory[0]);
        }
    }
}
