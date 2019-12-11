using IntcodeInterpreter.Enums;
using System.Collections.Generic;

namespace IntcodeInterpreter.Instructions
{
    public class Exit : InstructionBase
    {
        internal Exit()
            : base(Instruction.Exit, 0)
        {
        }

        public override long? Execute(Dictionary<long, long> program, long instructionIndex, long relativeBase, long? input)
        {
            return null;
        }
    }
}
