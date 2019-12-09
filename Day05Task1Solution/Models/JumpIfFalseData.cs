using Day05Task1Solution.Enums;

namespace Day05Task1Solution.Models
{
    internal class JumpIfFalseData : InstructionData
    {
        public JumpIfFalseData(int parameters)
            : base(Instruction.JumpIfFalse, 3)
        {
            NounMode = (Mode)(parameters % 10);
            ResultMode = (Mode)((parameters / 10) % 10);
        }

        public Mode NounMode { get; private set; }
        public Mode ResultMode { get; private set; }

        public override int? Execute(int[] program, int instructionIndex, int? input)
        {
            int value = GetValue(program, NounMode, instructionIndex + 1);
            if (value == 0)
            {
                SetJumpTo(program, ResultMode, instructionIndex + 2);
            }

            return null;
        }
    }
}