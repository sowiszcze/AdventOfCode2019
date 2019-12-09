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
            return Run(program, new Input(input)).Output;
        }

        public static Result Run(int[] program, Input input)
        {
            var outputs = new List<int>();
            var index = 0;
            InstructionData instructionData;
            do
            {
                instructionData = InstructionData.CreateInstructionData(program[index]);

                if (instructionData.Instruction == Instruction.Exit)
                {
                    break;
                }

                int? inputValue = null;
                if (instructionData.Instruction == Instruction.Input)
                {
                    if (input.HasMore())
                    {
                        inputValue = input.Next();
                    }
                    else
                    {
                        return new Result { Output = outputs, Status = Status.NeedsMoreInput };
                    }
                }
                int? result = instructionData.Execute(program, index, inputValue);

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
            
            return new Result { Output = outputs, Status = Status.RanToCompletion };
        }
    }
}
