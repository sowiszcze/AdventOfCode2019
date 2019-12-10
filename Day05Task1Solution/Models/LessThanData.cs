using Day05Task1Solution.Enums;
using System.Collections.Generic;

namespace Day05Task1Solution.Models
{
    internal class LessThanData : InstructionData
    {
        public LessThanData(long parameters)
            : base(Instruction.LessThan, 4)
        {
            NounMode = (Mode)(parameters % 10);
            VerbMode = (Mode)((parameters / 10) % 10);
            ResultMode = (Mode)((parameters / 100) % 10);
        }

        public Mode NounMode { get; private set; }
        public Mode VerbMode { get; private set; }
        public Mode ResultMode { get; private set; }

        public override long? Execute(Dictionary<long, long> program, long instructionIndex, long relativeBase, long? input)
        {
            long valueFirst = GetValue(program, NounMode, instructionIndex + 1, relativeBase);
            long valueSecond = GetValue(program, VerbMode, instructionIndex + 2, relativeBase);
            SetValue(program, ResultMode, instructionIndex + 3, relativeBase, valueFirst < valueSecond ? 1 : 0);

            return null;
        }
    }
}