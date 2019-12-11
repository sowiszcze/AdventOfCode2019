using Day08Task1Solution;
using Shared.Constants;
using Shared.Helpers;

namespace Day08Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.PrintResult(ConsoleHelper.Render(Solution.FlattenImage(Solution.CreateImage(Data.Image, 25, 6)), CharacterMaps.BitInverted));
        }
    }
}
