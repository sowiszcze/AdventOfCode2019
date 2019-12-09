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
            return Run(program, new int[] { input });
        }

        public static IList<int> Run(int[] program, int[] input)
        {
            var outputs = new List<int>();
            var index = 0;
            var inputIndex = 0;
            InstructionData instructionData;
            do
            {
                instructionData = InstructionData.CreateInstructionData(program[index]);

                if (instructionData.Instruction == Instruction.Exit)
                {
                    break;
                }

                int? result = instructionData.Execute(program, index, input[inputIndex]);

                if (instructionData.Instruction == Instruction.Input)
                {
                    inputIndex = Math.Min(inputIndex + 1, input.Length - 1);
                }

                bool previousWasOutput = result.HasValue;
                if (previousWasOutput)
                {
                    outputs.Add(result.Value);
                }

                index += instructionData.Length;
                if ((instructionData.Instruction == Instruction.JumpIfFalse || instructionData.Instruction == Instruction.JumpIfTrue) && instructionData.JumpTo.HasValue)
                {
                    index = instructionData.JumpTo.Value;
                }
            } while (instructionData.Length > 0);
            
            return outputs;
        }
    }
}
