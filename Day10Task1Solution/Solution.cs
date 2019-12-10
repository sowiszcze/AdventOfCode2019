using Day10Task1Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10Task1Solution
{
    public static class Solution
    {
        private const char AsteroidCharacter = '#';

        public static IEnumerable<Asteroid> GetAsteroids(string[] map)
        {
            for (var y = 0; y < map.Length; y++)
            {
                for (var x = 0; x < map[y].Length; x++)
                {
                    if (map[y][x] == AsteroidCharacter)
                    {
                        yield return new Asteroid(x, y);
                    }
                }
            }
        }

        public static IEnumerable<Observatory> GetObservatories(IEnumerable<Asteroid> asteroids)
        {
            foreach (var source in asteroids)
            {
                int inView = 0;
                foreach (var destination in asteroids)
                {
                    if (source == destination)
                    {
                        continue;
                    }
                    var middlePoints = source.GetMiddlePoints(destination);
                    if (!middlePoints.Any() || !asteroids.Any(a => middlePoints.Any(p => a.IsPlacedAt(p))))
                    {
                        inView++;
                    }
                }
                yield return new Observatory(source, inView);
            }
        }

        public static Observatory FindObservatoryWithBestVisibility(IEnumerable<Observatory> observatories)
        {
            return observatories.OrderByDescending(o => o.InView).First();
        }
    }
}
