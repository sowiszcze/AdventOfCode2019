using System;

namespace Day01Task1Solution
{
    public static class Solution
    {
        public static int Calculate(int mass)
        {
            return Convert.ToInt32(Math.Floor((double)mass / 3.0) - 2);
        }
    }
}
