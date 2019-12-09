using System;
using System.Collections.Generic;
using System.Linq;

namespace Day07Task1Solution
{
    public static class Solution
    {
        public static int FindBestSettings(int[] program, int input, int amplifiers, int minValue, int maxValue)
        {
            int thrusterValue = 0;
            IEnumerable<int[]> possiblePhases = GetPossiblePhases(Enumerable.Range(minValue, maxValue - minValue + 1));
            foreach (var phases in possiblePhases)
            {
                thrusterValue = Math.Max(thrusterValue, RunAmplifiers(program.Clone() as int[], input, phases));
            }
            return thrusterValue;
        }

        public static int RunAmplifiers(int[] program, int input, int[] phases)
        {
            var previousOutput = input;
            foreach (var phase in phases)
            {
                previousOutput = Day05Task1Solution.Solution.Run(program, new int[] { phase, previousOutput }).First();
            }
            return previousOutput;
        }

        private static IEnumerable<int[]> GetPossiblePhases(IEnumerable<int> possibleValues)
        {
            var permutations = new List<int[]>();
            if (possibleValues.Count() == 1)
            {
                permutations.Add(possibleValues.ToArray());
                return permutations;
            }

            foreach (var value in possibleValues)
            {
                permutations.AddRange(MergePossiblePhases(value, GetPossiblePhases(possibleValues.Except(new int[] { value }))));
            }

            return permutations;
        }

        private static IEnumerable<int[]> MergePossiblePhases(int value, IEnumerable<int[]> permutations)
        {
            return permutations.Select(p => p.Union(new int[] { value }).ToArray());
        }
    }
}
