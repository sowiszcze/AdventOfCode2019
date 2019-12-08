using Day05Task1Solution.Enums;
using Day05Task1Solution.Models;
using System;
using System.Collections.Generic;

namespace Day05Task1Solution
{
    public static class Solution
    {
        public static IList<int> Run(int[] program, int input)
        {
            var outputs = new List<int>();
            var index = 0;
            var previousWasOutput = false;
            InstructionData instructionData;
            do
            {
                instructionData = InstructionData.CreateInstructionData(program[index]);
                if (instructionData.Instruction == Instruction.Exit)
                {
                    break;
                }
                int? result = instructionData.Execute(program, index, input);
                previousWasOutput = result.HasValue;
                if (previousWasOutput)
                {
                    outputs.Add(result.Value);
                }
                index += instructionData.Length;
            } while (instructionData.Length > 0);

            if (!previousWasOutput)
            {
                throw new Exception("Last instruction was not output.");
            }

            return outputs;
        }
    }
}
