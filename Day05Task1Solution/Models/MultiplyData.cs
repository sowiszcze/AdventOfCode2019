using Day05Task1Solution.Enums;

namespace Day05Task1Solution.Models
{
    public class MultiplyData : InstructionData
    {
        internal MultiplyData(int parameters)
            : base(Instruction.Multiply, 4)
        {
            NounMode = (Mode)(parameters % 10);
            VerbMode = (Mode)((parameters / 10) % 10);
            ResultMode = (Mode)((parameters / 100) % 10);
        }

        public Mode NounMode { get; private set; }
        public Mode VerbMode { get; private set; }
        public Mode ResultMode { get; private set; }

        public override int? Execute(int[] program, int instructionIndex, int? input)
        {
            SetValue(
                program,
                ResultMode,
                instructionIndex + 3,
                GetValue(program, NounMode, instructionIndex + 1) * GetValue(program, VerbMode, instructionIndex + 2)
            );
            return null;
        }
    }
}
