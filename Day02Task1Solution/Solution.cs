using System;

namespace Day02Task1Solution
{
    public static class Solution
    {
        public static long[] Fix(long[] program, long noun, long verb)
        {
            long[] memory = program.Clone() as long[];
            memory[1] = noun;
            memory[2] = verb;
            return memory;
        }
    }
}
