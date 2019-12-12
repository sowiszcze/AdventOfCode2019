using Day12Task1Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day12Task1Solution
{
    public static class Solution
    {
        public static int CalculateEnergy(string[] moonsStrings, int steps)
        {
            var moons = moonsStrings.Select(m => Regex.Match(m, @"<x=(-?\d+), y=(-?\d+), z=(-?\d+)>")).Select(r => new Moon(int.Parse(r.Groups[1].Value), int.Parse(r.Groups[2].Value), int.Parse(r.Groups[3].Value))).ToArray();

            for (var i = 0; i < steps; i++)
            {
                foreach (var moon in moons)
                {
                    foreach (var otherMoon in moons.Where(m => m != moon))
                    {
                        moon.Velocity.Adapt(moon, otherMoon);
                    }
                }

                foreach (var moon in moons)
                {
                    moon.ApplyVelocity();
                }
            }

            return moons.Sum(m => m.Energy);
        }
    }
}
