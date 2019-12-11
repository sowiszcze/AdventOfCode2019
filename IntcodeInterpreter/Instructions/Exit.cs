using IntcodeInterpreter.Enums;
using System.Collections.Generic;

namespace IntcodeInterpreter.Instructions
{
    internal class Exit : InstructionBase
    {
        public Exit(long parameters)
            : base(Instruction.Exit, 0)
        {
        }

        internal override long? Execute(Dictionary<long, long> program, long instructionIndex, long relativeBase, long? input)
        {
            return null;
        }
    }
}
