using Day05Task1Solution.Enums;

namespace Day05Task1Solution.Models
{
    public class InputData : InstructionData
    {
        internal InputData(int parameters)
            : base(Instruction.Input, 2)
        {
            ResultMode = (Mode)(parameters % 10);
        }

        public Mode ResultMode { get; private set; }

        public override int? Execute(int[] program, int instructionIndex, int? input)
        {
            SetValue(
                program,
                ResultMode,
                instructionIndex + 1,
                input.Value
            );
            return null;
        }
    }
}
