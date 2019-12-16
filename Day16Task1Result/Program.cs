using Day16Task1Solution;
using Shared.Helpers;
using System.Linq;

namespace Day16Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var fft = new FFT(new int[] { 0, 1, 0, -1 });
            ConsoleHelper.PrintResult(string.Join("", fft.Decode(Data.Input, 100).Take(8)));
        }
    }
}
