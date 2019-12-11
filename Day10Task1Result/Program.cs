using Day10Task1Solution;
using Shared.Helpers;
using System.Linq;

namespace Day10Task1Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var asteroids = Solution.GetAsteroids(Data.Map).ToArray();
            var observatories = Solution.GetObservatories(asteroids).ToArray();
            var observatory = Solution.FindObservatoryWithBestVisibility(observatories);
            ConsoleHelper.PrintResult(observatory.InView);
        }
    }
}
