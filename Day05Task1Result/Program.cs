using Day05Task1Solution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day05Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> result = Solution.Run(Data.Program, 1);
            if (result.Take(result.Count - 1).Any(r => r != 0))
            {
                throw new Exception("Not all tests passed.");
            }
            Console.WriteLine($"The result is: {result.Last()}");
        }
    }
}
