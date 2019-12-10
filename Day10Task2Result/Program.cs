using Day10Task1Solution;
using System;
using System.Linq;

namespace Day10Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var asteroids = Solution.GetAsteroids(Data.Map).ToArray();
            var observatories = Solution.GetObservatories(asteroids).ToArray();
            var observatory = Solution.FindObservatoryWithBestVisibility(observatories);
            var yote = Solution.AsteroidsToYeet(observatory.Asteroid, asteroids);
            Console.WriteLine($"The result is: {yote[199].X * 100 + yote[199].Y}");
        }
    }
}
