using Day05Task1Solution.Enums;

namespace Day05Task1Solution.Models
{
    public class ExitData : InstructionData
    {
        internal ExitData()
            : base(Instruction.Exit, 0)
        {
        }

        public override int? Execute(int[] program, int instructionIndex, int? input)
        {
            return null;
        }
    }
}
