using IntcodeInterpreter;
using IntcodeInterpreter.Enums;
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
            var interpreters = phases.Select(p => new Interpreter(program)).ToArray();

            do
            {
                for (var i = 0; i < phases.Length; i++)
                {
                    var interpreter = interpreters[i];

                    long[] inputs;
                    long phase = phases[i];

                    if (i == 0)
                    {
                        inputs = new long[] { baseInput }.Concat(interpreters[phases.Length - 1].Output).ToArray();
                    }
                    else
                    {
                        inputs = interpreters[i - 1].Output.ToArray();
                    }
                    interpreter.SetInput(new long[] { phase }.Concat(inputs).ToArray());
                    interpreter.Run();
                }
            } while (interpreters.Any(s => s.Status != Status.RanToCompletion));

            if (interpreters.Any(s => s.Status != Status.RanToCompletion))
            {
                throw new Exception("Not all amplifiers completed their work.");
            }

            return interpreters.Select((o, i) => (i, o.Output.ToArray())).ToDictionary(k => k.i, v => v.Item2);
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
