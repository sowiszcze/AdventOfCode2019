﻿using Day05Task1Solution.Enums;
using System.Collections.Generic;

namespace Day05Task1Solution.Models
{
    public class InputData : InstructionData
    {
        internal InputData(long parameters)
            : base(Instruction.Input, 2)
        {
            ResultMode = (Mode)(parameters % 10);
        }

        public Mode ResultMode { get; private set; }

        public override long? Execute(Dictionary<long, long> program, long instructionIndex, long relativeBase, long? input)
        {
            SetValue(
                program,
                ResultMode,
                instructionIndex + 1,
                relativeBase,
                input.Value
            );
            return null;
        }
    }
}
