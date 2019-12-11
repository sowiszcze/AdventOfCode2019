using IntcodeInterpreter.Enums;
using IntcodeInterpreter.Exceptions;
using IntcodeInterpreter.Instructions;
using IntcodeInterpreter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace IntcodeInterpreter
{
    public class Interpreter
    {
        private readonly Dictionary<long, long> memory;
        private readonly IList<long> output;

        public Interpreter(long[] program)
        {
            memory = program.Select((v, i) => (Convert.ToInt64(i), v)).ToDictionary(k => k.Item1, v => v.v);
            output = new List<long>();
        }

        public IList<long> RunToCompletion()
        {
            var result = Run(new InputData());
            if (result.Status != Status.RanToCompletion)
            {
                throw new ExecutionException($"Intcode interpreter halted with status {result.Status}.");
            }
            return result.Output;
        }

        public IList<long> RunToCompletion(long input)
        {
            var result = Run(new InputData(input));
            if (result.Status != Status.RanToCompletion)
            {
                throw new ExecutionException($"Intcode interpreter halted with status {result.Status}.");
            }
            return result.Output;
        }

        public IList<long> RunToCompletion(InputData input)
        {
            var result = Run(input);
            if (result.Status != Status.RanToCompletion)
            {
                throw new ExecutionException($"Intcode interpreter halted with status {result.Status}.");
            }
            return result.Output;
        }

        public Result Run()
        {
            return Run(new InputData());
        }

        public Result Run(long input)
        {
            return Run(new InputData(input));
        }

        public Result Run(InputData input)
        {
            var index = 0L;
            var relativeBase = 0L;
            InstructionBase instructionData;
            do
            {
                instructionData = InstructionBase.CreateInstruction(memory[index]);

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
                        return new Result { Output = output, Status = Status.NeedsMoreInput };
                    }
                }
                long? result = instructionData.Execute(memory, index, relativeBase, inputValue);

                if (instructionData.Instruction == Instruction.Output)
                {
                    output.Add(result.Value);
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
            
            return new Result { Output = output, Status = Status.RanToCompletion };
        }

        public IReadOnlyDictionary<long, long> Memory => new ReadOnlyDictionary<long, long>(memory);
        public IReadOnlyList<long> Output => output as IReadOnlyList<long>;
    }
}
