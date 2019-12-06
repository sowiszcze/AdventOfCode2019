using System;

namespace Day02Task1Solution
{
    public static class Solution
    {
        public static int[] Calculate(int[] program)
        {
            int[] memory = program.Clone() as int[];
            int instruction,
                noun,
                verb,
                resultIndex;
            for (int index = 0; memory[index] != 99; index += 4)
            {
                instruction = memory[index];
                noun = memory[memory[index + 1]];
                verb = memory[memory[index + 2]];
                resultIndex = memory[index + 3];
                switch (instruction)
                {
                    case 1: // addition
                        memory[resultIndex] = noun + verb;
                        break;
                    case 2: // addition
                        memory[resultIndex] = noun * verb;
                        break;
                    default:
                        throw new ArgumentException($"Unsupported instruction {instruction} at index {index}.");
                }
            }
            return memory;
        }

        public static int[] Fix(int[] program)
        {
            int[] memory = program.Clone() as int[];
            memory[1] = 12;
            memory[2] = 2;
            return memory;
        }

        public static int GetResult(this int[] memory)
        {
            return memory[0];
        }
    }
}
