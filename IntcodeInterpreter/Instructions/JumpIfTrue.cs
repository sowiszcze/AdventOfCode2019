using IntcodeInterpreter.Enums;
using System.Collections.Generic;

namespace IntcodeInterpreter.Instructions
{
    internal class JumpIfTrue : InstructionBase
    {
        public JumpIfTrue(long parameters)
            : base(Instruction.JumpIfTrue, 3)
        {
            NounMode = (Mode)(parameters % 10);
            ResultMode = (Mode)((parameters / 10) % 10);
        }

        internal Mode NounMode { get; private set; }
        internal Mode ResultMode { get; private set; }

        internal override long? Execute(Dictionary<long, long> program, long instructionIndex, long relativeBase, long? input)
        {
            long value = GetValue(program, NounMode, instructionIndex + 1, relativeBase);
            if (value != 0)
            {
                SetJumpTo(program, ResultMode, instructionIndex + 2, relativeBase);
            }

            return null;
        }
    }
}