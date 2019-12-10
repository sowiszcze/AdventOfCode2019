using Day10Task1Solution;
using System;
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
            Console.WriteLine($"The result is: {observatory.InView}");
        }
    }
}
