using IntcodeInterpreter.Enums;
using System;
using System.Collections.Generic;

namespace IntcodeInterpreter.Instructions
{
    public abstract class InstructionBase
    {
        public static InstructionBase CreateInstruction(long data)
        {
            var instructionInfo = (Instruction)(data % 100);
            long instructionParams = data / 100;
            switch (instructionInfo)
            {
                case Instruction.Add:
                    return new Add(instructionParams);
                case Instruction.Multiply:
                    return new Multiply(instructionParams);
                case Instruction.Input:
                    return new Input(instructionParams);
                case Instruction.Output:
                    return new Output(instructionParams);
                case Instruction.JumpIfTrue:
                    return new JumpIfTrue(instructionParams);
                case Instruction.JumpIfFalse:
                    return new JumpIfFalse(instructionParams);
                case Instruction.LessThan:
                    return new LessThan(instructionParams);
                case Instruction.Equals:
                    return new Equals(instructionParams);
                case Instruction.AdjustRelativeBase:
                    return new AdjustRelativeBase(instructionParams);
                case Instruction.Exit:
                    return new Exit();
                default:
                    throw new NotImplementedException($"Instruction {instructionInfo} is not implemented. Reference data: {data}.");
            }
        }
        
        protected InstructionBase(Instruction instruction, long length)
        {
            Instruction = instruction;
            Length = length;
        }

        public Instruction Instruction { get; private set; }
        public long Length { get; private set; }
        public long? JumpTo { get; private set; }

        public abstract long? Execute(Dictionary<long, long> program, long instructionIndex, long relativeBase, long? input);

        protected long GetValue(Dictionary<long, long> program, Mode mode, long index, long relativeBase)
        {
            switch (mode)
            {
                case Mode.Immediate:
                    return Get(program, index);
                case Mode.Position:
                    return Get(program, Get(program, index));
                case Mode.Relative:
                    return Get(program, relativeBase + Get(program, index));
                default:
                    throw new NotImplementedException($"Mode {mode} is not implemented.");
            }
        }

        protected void SetValue(Dictionary<long, long> program, Mode mode, long index, long relativeBase, long value)
        {
            
            switch (mode)
            {
                case Mode.Immediate:
                    program[index] = value;
                    break;
                case Mode.Position:
                    program[Get(program, index)] = value;
                    break;
                case Mode.Relative:
                    program[relativeBase + Get(program, index)] = value;
                    break;
                default:
                    throw new NotImplementedException($"Mode {mode} is not implemented.");
            }
        }

        protected void SetJumpTo(Dictionary<long, long> program, Mode mode, long index, long relativeBase)
        {
            switch (mode)
            {
                case Mode.Immediate:
                    JumpTo = Get(program, index);
                    break;
                case Mode.Position:
                    JumpTo = Get(program, Get(program, index));
                    break;
                case Mode.Relative:
                    JumpTo = Get(program, relativeBase + Get(program, index));
                    break;
                default:
                    throw new NotImplementedException($"Mode {mode} is not implemented.");
            }
        }

        private long Get(Dictionary<long, long> program, long index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return program.ContainsKey(index) ? program[index] : 0;
        }
    }
}
