﻿using Day01Task2Solution;
using System;

namespace Day01Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            foreach (int mass in Data.Masses)
            {
                sum += Solution.Calculate(mass);
            }
            Console.WriteLine($"The result is: {sum}");
        }
    }
}
