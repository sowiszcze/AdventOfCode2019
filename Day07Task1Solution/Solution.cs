using Day05Task1Solution.Enums;
using Day05Task1Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day07Task1Solution
{
    public static class Solution
    {
        public static int FindBestSettings(int[] program, int baseInput, int minValue, int maxValue)
        {
            int thrusterValue = 0;
            int amplifiers = maxValue - minValue + 1;
            IEnumerable<int[]> possiblePhases = GetPossiblePhases(Enumerable.Range(minValue, amplifiers));
            foreach (var phases in possiblePhases)
            {
                thrusterValue = Math.Max(thrusterValue, RunAmplifiers(program.Clone() as int[], baseInput, phases)[amplifiers - 1].Last());
            }
            return thrusterValue;
        }

        public static Dictionary<int, int[]> RunAmplifiers(int[] program, int baseInput, int[] phases)
        {
            var outputs = Enumerable.Repeat(new int[] { }, phases.Length).ToArray();
            var statuses = Enumerable.Repeat(Status.NeedsMoreInput, phases.Length).ToArray();

            do
            {
                for (var i = 0; i < phases.Length; i++)
                {
                    int[] inputs;
                    int phase = phases[i];

                    if (i == 0)
                    {
                        inputs = new int[] { baseInput }.Concat(outputs[phases.Length - 1]).ToArray();
                    }
                    else
                    {
                        inputs = outputs[i - 1];
                    }

                    var result = Day05Task1Solution.Solution.Run(program.Clone() as int[], new Input(new int[] { phase }.Concat(inputs).ToArray()));
                    outputs[i] = result.Output.ToArray();
                    statuses[i] = result.Status;
                }
            } while (statuses.Any(s => s != Status.RanToCompletion));

            if (statuses.Any(s => s != Status.RanToCompletion))
            {
                throw new Exception("Not all amplifiers completed their work.");
            }

            return outputs.Select((o, i) => (i, o)).ToDictionary(k => k.i, v => v.o);
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
            return permutations.Select(p => p.Concat(new int[] { value }).ToArray());
        }
    }
}
