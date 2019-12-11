using IntcodeInterpreter.Enums;
using System.Collections.Generic;

namespace IntcodeInterpreter.Instructions
{
    public class AdjustRelativeBase : InstructionBase
    {
        internal AdjustRelativeBase(long parameters)
            : base(Instruction.AdjustRelativeBase, 2)
        {
            ResultMode = (Mode)(parameters % 10);
        }

        public Mode ResultMode { get; private set; }

        public override long? Execute(Dictionary<long, long> program, long instructionIndex, long relativeBase, long? input)
        {
            return relativeBase + GetValue(
                program,
                ResultMode,
                instructionIndex + 1,
                relativeBase
            );
        }
    }
}
