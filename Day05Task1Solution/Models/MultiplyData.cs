using Day05Task1Solution.Enums;
using System.Collections.Generic;

namespace Day05Task1Solution.Models
{
    public class MultiplyData : InstructionData
    {
        internal MultiplyData(long parameters)
            : base(Instruction.Multiply, 4)
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
            SetValue(
                program,
                ResultMode,
                instructionIndex + 3,
                relativeBase,
                GetValue(program, NounMode, instructionIndex + 1, relativeBase) * GetValue(program, VerbMode, instructionIndex + 2, relativeBase)
            );
            return null;
        }
    }
}
