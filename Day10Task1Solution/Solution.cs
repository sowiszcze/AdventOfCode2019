using Day10Task1Solution.Models;
using System;
using System.Collections.Generic;

namespace Day10Task1Solution
{
    public static class Solution
    {
        private const char AsteroidCharacter = '#';

        public static IEnumerable<Asteroid> GetAsteroids(string[] map)
        {
            var asteroids = new List<Asteroid>();
            for (var y = 0; y < map.Length; y++)
            {
                for (var x = 0; x < map[y].Length; x++)
                {
                    if (map[y][x] == AsteroidCharacter)
                    {
                        asteroids.Add(new Asteroid(x, y));
                    }
                }
            }
            return asteroids;
        }
    }
}
