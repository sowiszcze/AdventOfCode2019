using System;
using Day04Task1Solution;

namespace Day04Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The result is: {Solution.CountValidCodes(Data.Lower, Data.Upper)}");
        }
    }
}