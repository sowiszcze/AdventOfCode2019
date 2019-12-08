using Day05Task1Solution.Enums;

namespace Day05Task1Solution.Models
{
    internal class EqualsData : InstructionData
    {
        public EqualsData(int parameters)
            : base(Instruction.Equals, 4)
        {
            NounMode = (Mode)(parameters % 10);
            VerbMode = (Mode)((parameters / 10) % 10);
            ResultMode = (Mode)((parameters / 100) % 10);
        }

        public Mode NounMode { get; private set; }
        public Mode VerbMode { get; private set; }
        public Mode ResultMode { get; private set; }

        public override int? Execute(int[] program, int instructionIndex, int input)
        {
            int valueFirst = GetValue(program, NounMode, instructionIndex + 1);
            int valueSecond = GetValue(program, VerbMode, instructionIndex + 2);
            SetValue(program, ResultMode, instructionIndex + 3, valueFirst == valueSecond ? 1 : 0);

            return null;
        }
    }
}