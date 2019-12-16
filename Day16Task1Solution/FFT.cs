using System;
using System.Linq;
using System.Threading.Tasks;

namespace Day16Task1Solution
{
    public class FFT
    {
        private readonly int[] pattern;

        public FFT(int[] pattern)
        {
            this.pattern = pattern;
        }

        public string DecodeWithOffset(string encoded, int phases, int length)
        {
            var offset = int.Parse(encoded.Substring(0, 7));
            return string.Join("", Decode(string.Join("", Enumerable.Repeat(encoded, 10000)), phases).Skip(offset).Take(length));
        }

        public int[] Decode(string encoded, int phases)
        {
            return Decode(encoded.ToCharArray().Select(e => (int)(e - '0')).ToArray(), phases);
        }

        public int[] Decode(int[] encoded, int phases)
        {
            var current = encoded.Clone() as int[];
            var calculatedPhases = new int[encoded.Length][];

            for (var d = 0; d < encoded.Length; d++)
            {
                calculatedPhases[d] = new int[encoded.Length];
                for (var i = 0; i < encoded.Length; i++)
                {
                    calculatedPhases[d][i] = pattern[Convert.ToInt32(Math.Floor((i + 1.0) / (d + 1.0))) % pattern.Length];
                }
            }

            for (int p = 0; p < phases; p++)
            {
                var calculated = new int[current.Length];
                Parallel.For(0, current.Length, (d) =>
                {
                    calculated[d] = Math.Abs(current.Select((e, i) => new
                    {
                        Digit = e,
                        Multiplier = calculatedPhases[d][i]
                    }).Sum(i => i.Digit * i.Multiplier)) % 10;
                });
                current = calculated;
            }
            return current;
        }
    }
}
