using Day12Task1Solution.Models;
using Shared.Helpers;
using Shared.Models;
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
            var moons = ParseMoons(moonsStrings);

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
        public static long CalculateLoopSteps(string[] moonsStrings)
        {
            var moons = ParseMoons(moonsStrings);
            var primalState = ParseMoons(moonsStrings);

            long stepsX = CalculateLoopSteps(moons.Select(m => new Moon(m.X, 0, 0)).ToArray(), primalState, p => p.X);
            long stepsY = CalculateLoopSteps(moons.Select(m => new Moon(0, m.Y, 0)).ToArray(), primalState, p => p.Y);
            long stepsZ = CalculateLoopSteps(moons.Select(m => new Moon(0, 0, m.Z)).ToArray(), primalState, p => p.Z);

            return IntegerHelper.LCM(IntegerHelper.LCM(stepsX, stepsY), stepsZ);
        }

        private static long CalculateLoopSteps(Moon[] moons, Moon[] primalState, Func<Point3D, int> selector)
        {
            long steps = 0;
            do
            {
                ++steps;
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
            } while (!IsLikeBeginning(moons, primalState, selector));

            return steps;
        }

        private static Moon[] ParseMoons(string[] moonsStrings)
        {
            return moonsStrings.Select(m => Regex.Match(m, @"<x=(-?\d+), y=(-?\d+), z=(-?\d+)>")).Select(r => new Moon(int.Parse(r.Groups[1].Value), int.Parse(r.Groups[2].Value), int.Parse(r.Groups[3].Value))).ToArray();
        }

        private static bool IsLikeBeginning(Moon[] currentState, Moon[] primalState, Func<Point3D, int> selector)
        {
            for (var i = 0; i < currentState.Count(); i++)
            {
                var current = currentState[i];
                var primal = primalState[i];

                if (selector(current) != selector(primal) ||
                    selector(current.Velocity) != selector(primal.Velocity))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
