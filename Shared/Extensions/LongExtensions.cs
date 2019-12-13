using System;

namespace Shared.Extensions
{
    public static class LongExtensions
    {
        public static long Normalize(this long number)
        {
            return number != 0 ? number / Math.Abs(number) : 0;
        }
    }
}
