using System;
using System.Linq;

namespace Day16Task1Solution
{
    public class FFT
    {
        private readonly int[] pattern;

        public FFT(int[] pattern)
        {
            this.pattern = pattern;
        }

        public int[] Decode(string encoded, int phases)
        {
            return Decode(encoded.ToCharArray().Select(e => (int)(e - '0')).ToArray(), phases);
        }

        public int[] Decode(int[] encoded, int phases)
        {
            var current = encoded.Clone() as int[];
            for (int p = 0; p < phases; p++)
            {
                var calculated = new int[current.Length];
                for (var d = 0; d < current.Length; d++)
                {
                    calculated[d] = Math.Abs(current.Select((e, i) => new
                    {
                        Digit = e,
                        Index = Convert.ToInt32(Math.Floor((i + 1.0) / (d + 1.0))) % pattern.Length
                    }).Sum(i => i.Digit * pattern[i.Index])) % 10;
                }
                current = calculated;
            }
            return current;
        }
    }
}
