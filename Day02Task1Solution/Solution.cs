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
                outputIndex;
            for (int index = 0; memory[index] != 99; index += 4)
            {
                instruction = memory[index];
                noun = memory[memory[index + 1]];
                verb = memory[memory[index + 2]];
                outputIndex = memory[index + 3];
                switch (instruction)
                {
                    case 1: // addition
                        memory[outputIndex] = noun + verb;
                        break;
                    case 2: // addition
                        memory[outputIndex] = noun * verb;
                        break;
                    default:
                        throw new ArgumentException($"Unsupported instruction {instruction} at index {index}.");
                }
            }
            return memory;
        }

        public static int[] Fix(int[] program, int noun, int verb)
        {
            int[] memory = program.Clone() as int[];
            memory[1] = noun;
            memory[2] = verb;
            return memory;
        }

        public static int GetResult(this int[] memory)
        {
            return memory[0];
        }
    }
}
