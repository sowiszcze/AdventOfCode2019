using IntcodeInterpreter.Enums;
using System.Collections.Generic;

namespace IntcodeInterpreter.Instructions
{
    internal class Multiply : InstructionBase
    {
        public Multiply(long parameters)
            : base(Instruction.Multiply, 4)
        {
            NounMode = (Mode)(parameters % 10);
            VerbMode = (Mode)((parameters / 10) % 10);
            ResultMode = (Mode)((parameters / 100) % 10);
        }

        internal Mode NounMode { get; private set; }
        internal Mode VerbMode { get; private set; }
        internal Mode ResultMode { get; private set; }

        internal override long? Execute(Dictionary<long, long> program, long instructionIndex, long relativeBase, long? input)
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
