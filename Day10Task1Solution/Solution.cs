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

        public static IList<Asteroid> AsteroidsToYeet(Asteroid source, IEnumerable<Asteroid> asteroids)
        {
            var toYeet = asteroids
                .Where(a => a != source)
                .GroupBy(a => source.CalculateVector(a).Angle)
                .ToArray();
            var maxInLine = toYeet.Max(y => y.Count());
            var yote = new List<Asteroid>();
            for (var i = 0; i < maxInLine; i++)
            {
                var layer = toYeet.Where(g => g.Count() > i);
                var ordered = layer.OrderBy(g => g.Key);
                var selected = ordered.Select(g => g.OrderBy(a => source.CalculateDistance(a)).ElementAt(i));
                yote.AddRange(selected);
            }
            return yote;
        }
    }
}
