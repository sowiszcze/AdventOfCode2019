using Day02Task1Solution;
using System;

namespace Day02Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] program = Data.Program;
            program[1] = 12;
            program[2] = 2;

            Console.WriteLine($"The result is: {Solution.Calculate(program)[0]}");
        }
    }
}
