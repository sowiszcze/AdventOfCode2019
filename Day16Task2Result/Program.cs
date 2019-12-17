using Day16Task1Solution;
using Shared.Helpers;
using System;

namespace Day16Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var fft = new FFT(new int[] { 0, 1, 0, -1 });
            ConsoleHelper.PrintResult(fft.FastDecodeWithOffset(Data.Input, 100, 8));
        }
    }
}
