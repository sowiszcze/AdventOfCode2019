using Day05Task1Solution.Enums;
using Day05Task1Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day07Task1Solution
{
    public static class Solution
    {
        public static long FindBestSettings(long[] program, long baseInput, int minValue, int maxValue)
        {
            long thrusterValue = 0;
            int amplifiers = maxValue - minValue + 1;
            var possiblePhases = GetPossiblePhases(Enumerable.Range(minValue, amplifiers).Select(x => Convert.ToInt64(x)));
            foreach (var phases in possiblePhases)
            {
                thrusterValue = Math.Max(thrusterValue, RunAmplifiers(program.Clone() as long[], baseInput, phases)[amplifiers - 1].Last());
            }
            return thrusterValue;
        }

        public static Dictionary<int, long[]> RunAmplifiers(long[] program, long baseInput, long[] phases)
        {
            var outputs = Enumerable.Repeat(new long[] { }, phases.Length).ToArray();
            var statuses = Enumerable.Repeat(Status.NeedsMoreInput, phases.Length).ToArray();

            do
            {
                for (var i = 0; i < phases.Length; i++)
                {
                    long[] inputs;
                    long phase = phases[i];

                    if (i == 0)
                    {
                        inputs = new long[] { baseInput }.Concat(outputs[phases.Length - 1]).ToArray();
                    }
                    else
                    {
                        inputs = outputs[i - 1];
                    }

                    var result = Day05Task1Solution.Solution.Run(program.Clone() as long[], new Input(new long[] { phase }.Concat(inputs).ToArray()));
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

        private static IEnumerable<long[]> GetPossiblePhases(IEnumerable<long> possibleValues)
        {
            var permutations = new List<long[]>();
            if (possibleValues.Count() == 1)
            {
                permutations.Add(possibleValues.ToArray());
                return permutations;
            }

            foreach (var value in possibleValues)
            {
                permutations.AddRange(MergePossiblePhases(value, GetPossiblePhases(possibleValues.Except(new long[] { value }))));
            }

            return permutations;
        }

        private static IEnumerable<long[]> MergePossiblePhases(long value, IEnumerable<long[]> permutations)
        {
            return permutations.Select(p => p.Concat(new long[] { value }).ToArray());
        }
    }
}
