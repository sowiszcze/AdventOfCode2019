using IntcodeInterpreter.Enums;
using System.Collections.Generic;

namespace IntcodeInterpreter.Instructions
{
    internal class AdjustRelativeBase : InstructionBase
    {
        public AdjustRelativeBase(long parameters)
            : base(Instruction.AdjustRelativeBase, 2)
        {
            ResultMode = (Mode)(parameters % 10);
        }

        internal Mode ResultMode { get; private set; }

        internal override long? Execute(Dictionary<long, long> program, long instructionIndex, long relativeBase, long? input)
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
