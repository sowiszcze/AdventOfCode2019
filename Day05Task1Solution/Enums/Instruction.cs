using System;
using System.Collections.Generic;
using System.Text;

namespace Day05Task1Solution.Enums
{
    public enum Instruction
    {
        Add = 1,
        Multiply = 2,
        Input = 3,
        Output = 4,
        JumpIfTrue = 5,
        JumpIfFalse = 6,
        LessThan = 7,
        Equals = 8,
        Exit = 99
    }
}
