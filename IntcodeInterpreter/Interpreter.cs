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
        private readonly InputData input;

        public Interpreter(long[] program)
        {
            memory = program.Select((v, i) => (Convert.ToInt64(i), v)).ToDictionary(k => k.Item1, v => v.v);
            input = new InputData();
            output = new List<long>();

            Index = 0;
            RelativeBase = 0;
            Status = Status.NotStarted;
        }

        public void AddInput(params long[] inputData)
        {
            input.Add(inputData);
        }

        public void SetInput(params long[] inputData)
        {
            input.Set(inputData);
        }

        public void RestartInput()
        {
            input.Restart();
        }

        public void Run()
        {
            Status = Status.Running;

            try
            {
                InstructionBase instructionData;
                do
                {
                    instructionData = InstructionBase.CreateInstruction(memory[Index]);

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
                            Status = Status.NeedsMoreInput;
                            return;
                        }
                    }
                    long? result = instructionData.Execute(memory, Index, RelativeBase, inputValue);

                    if (instructionData.Instruction == Instruction.Output)
                    {
                        output.Add(result.Value);
                    }
                    else if (instructionData.Instruction == Instruction.AdjustRelativeBase)
                    {
                        RelativeBase = result.Value;
                    }

                    Index += instructionData.Length;
                    if ((instructionData.Instruction == Instruction.JumpIfFalse || instructionData.Instruction == Instruction.JumpIfTrue) && instructionData.JumpTo.HasValue)
                    {
                        Index = instructionData.JumpTo.Value;
                    }
                } while (instructionData.Length > 0);

                Status = Status.RanToCompletion;
            }
            catch (Exception ex)
            {
                Status = Status.Faulted;
                throw new ExecutionException("There was an error during runtime of interpreter. See inner exception for more dateils", ex);
            }
        }

        public void AssureCompletion()
        {
            if (Status != Status.RanToCompletion)
            {
                throw new ExecutionException($"Interpreter finished with status {Status}.");
            }
        }

        public Status Status { get; private set; }

        public long Index { get; private set; }

        public long RelativeBase { get; private set; }

        public IReadOnlyList<long> Memory => memory.Values.ToList().AsReadOnly();

        public IReadOnlyList<long> Output => output.ToList().AsReadOnly();
    }
}
