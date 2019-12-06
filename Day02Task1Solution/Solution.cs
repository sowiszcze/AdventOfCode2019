using System;

namespace Day02Task1Solution
{
    public static class Solution
    {
        public static int[] Calculate(int[] program)
        {
            int[] result = program.Clone() as int[];
            int instruction,
                firstIndex,
                secondIndex,
                resultIndex;
            for (int index = 0; result[index] != 99; index += 4)
            {
                instruction = result[index];
                firstIndex = result[index + 1];
                secondIndex = result[index + 2];
                resultIndex = result[index + 3];
                switch (instruction)
                {
                    case 1: // addition
                        result[resultIndex] = result[firstIndex] + result[secondIndex];
                        break;
                    case 2: // addition
                        result[resultIndex] = result[firstIndex] * result[secondIndex];
                        break;
                    default:
                        throw new ArgumentException($"Unsupported instruction {instruction} at index {index}.");
                }
            }
            return result;
        }
    }
}
