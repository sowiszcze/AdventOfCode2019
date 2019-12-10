using Day05Task1Solution.Enums;
using System.Collections.Generic;

namespace Day05Task1Solution.Models
{
    public class ExitData : InstructionData
    {
        internal ExitData()
            : base(Instruction.Exit, 0)
        {
        }

        public override long? Execute(Dictionary<long, long> program, long instructionIndex, long relativeBase, long? input)
        {
            return null;
        }
    }
}
