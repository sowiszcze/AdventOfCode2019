using Day05Task1Solution.Enums;

namespace Day05Task1Solution.Models
{
    public class OutputData : InstructionData
    {
        internal OutputData(int parameters)
            : base(Instruction.Output, 2)
        {
            ResultMode = (Mode)(parameters % 10);
        }

        public Mode ResultMode { get; private set; }

        public override int? Execute(int[] program, int instructionIndex, int input)
        {
            return GetValue(
                program,
                ResultMode,
                instructionIndex + 1
            );
        }
    }
}
