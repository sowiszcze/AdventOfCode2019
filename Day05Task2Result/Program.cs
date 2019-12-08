using Day05Task1Solution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day05Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> result = Solution.Run(Data.Program, 5);
            if (result.Count > 1)
            {
                throw new Exception("Too many outputs.");
            }
            Console.WriteLine($"The result is: {result.Last()}");
        }
    }
}
