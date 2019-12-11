using IntcodeInterpreter.Enums;
using System;
using System.Collections.Generic;

namespace IntcodeInterpreter.Instructions
{
    internal abstract class InstructionBase
    {
        internal static InstructionBase CreateInstruction(long data)
        {
            var instruction = (Instruction)(data % 100);
            long instructionParams = data / 100;

            return Activator.CreateInstance(Type.GetType($"IntcodeInterpreter.Instructions.{instruction}", true, true), new object[] { instructionParams }) as InstructionBase;
        }
        
        protected InstructionBase(Instruction instruction, long length)
        {
            Instruction = instruction;
            Length = length;
        }

        internal Instruction Instruction { get; private set; }
        internal long Length { get; private set; }
        internal long? JumpTo { get; private set; }

        internal abstract long? Execute(Dictionary<long, long> program, long instructionIndex, long relativeBase, long? input);

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
