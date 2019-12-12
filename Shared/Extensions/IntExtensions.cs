using System;

namespace Shared.Extensions
{
    public static class IntExtensions
    {
        public static int Normalize(this int number)
        {
            return number != 0 ? number / Math.Abs(number) : 0;
        }
    }
}
