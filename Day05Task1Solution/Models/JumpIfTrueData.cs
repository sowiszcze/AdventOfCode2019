using Day05Task1Solution.Enums;
using System.Collections.Generic;

namespace Day05Task1Solution.Models
{
    internal class JumpIfTrueData : InstructionData
    {
        public JumpIfTrueData(long parameters)
            : base(Instruction.JumpIfTrue, 3)
        {
            NounMode = (Mode)(parameters % 10);
            ResultMode = (Mode)((parameters / 10) % 10);
        }

        public Mode NounMode { get; private set; }
        public Mode ResultMode { get; private set; }

        public override long? Execute(Dictionary<long, long> program, long instructionIndex, long relativeBase, long? input)
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