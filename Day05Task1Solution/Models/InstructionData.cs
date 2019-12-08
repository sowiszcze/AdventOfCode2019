using Day05Task1Solution.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day05Task1Solution.Models
{
    public abstract class InstructionData
    {
        public static InstructionData CreateInstructionData(int data)
        {
            var instructionInfo = (Instruction)(data % 100);
            int instructionParams = data / 100;
            switch (instructionInfo)
            {
                case Instruction.Add:
                    return new AddData(instructionParams);
                case Instruction.Multiply:
                    return new MultiplyData(instructionParams);
                case Instruction.Input:
                    return new InputData(instructionParams);
                case Instruction.Output:
                    return new OutputData(instructionParams);
                case Instruction.JumpIfTrue:
                    return new JumpIfTrueData(instructionParams);
                case Instruction.JumpIfFalse:
                    return new JumpIfFalseData(instructionParams);
                case Instruction.LessThan:
                    return new LessThanData(instructionParams);
                case Instruction.Equals:
                    return new EqualsData(instructionParams);
                case Instruction.Exit:
                    return new ExitData();
                default:
                    throw new NotImplementedException($"Instruction {instructionInfo} is not implemented. Reference data: {data}.");
            }
        }
        
        protected InstructionData(Instruction instruction, int length)
        {
            Instruction = instruction;
            Length = length;
        }

        public Instruction Instruction { get; private set; }
        public int Length { get; private set; }
        public int? JumpTo { get; private set; }

        public abstract int? Execute(int[] program, int instructionIndex, int input);

        protected int GetValue(int[] program, Mode mode, int index)
        {
            switch (mode)
            {
                case Mode.Immediate:
                    return program[index];
                case Mode.Position:
                    return program[program[index]];
                default:
                    throw new NotImplementedException($"Mode {mode} is not implemented.");
            }
        }

        protected void SetValue(int[] program, Mode mode, int index, int value)
        {
            
            switch (mode)
            {
                case Mode.Immediate:
                    program[index] = value;
                    break;
                case Mode.Position:
                    program[program[index]] = value;
                    break;
                default:
                    throw new NotImplementedException($"Mode {mode} is not implemented.");
            }
        }

        protected void SetJumpTo(int[] program, Mode mode, int index)
        {
            switch (mode)
            {
                case Mode.Immediate:
                    JumpTo = program[index];
                    break;
                case Mode.Position:
                    JumpTo = program[program[index]];
                    break;
                default:
                    throw new NotImplementedException($"Mode {mode} is not implemented.");
            }
        }
    }
}
