using Day05Task1Solution.Enums;
using Day05Task1Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day05Task1Solution
{
    public static class Solution
    {
        public static IList<long> Run(long[] program)
        {
            return Run(program, new Input()).Output;
        }

        public static IList<long> Run(long[] program, long input)
        {
            return Run(program, new Input(input)).Output;
        }

        public static Result Run(long[] program, Input input)
        {
            var memory = program.Select((v, i) => (Convert.ToInt64(i), v)).ToDictionary(k => k.Item1, v => v.v);
            var outputs = new List<long>();
            var index = 0L;
            var relativeBase = 0L;
            InstructionData instructionData;
            do
            {
                instructionData = InstructionData.CreateInstructionData(memory[index]);

                if (instructionData.Instruction == Instruction.Exit)
                {
                    break;
                }

                long? inputValue = null;
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
                long? result = instructionData.Execute(memory, index, relativeBase, inputValue);

                if (instructionData.Instruction == Instruction.Output)
                {
                    outputs.Add(result.Value);
                }
                else if (instructionData.Instruction == Instruction.AdjustRelativeBase)
                {
                    relativeBase = result.Value;
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
