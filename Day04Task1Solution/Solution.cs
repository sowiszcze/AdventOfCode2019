using System;

namespace Day04Task1Solution
{
    public static class Solution
    {
        public static bool IsValid(int code)
        {
            char[] characters = code.ToString().ToCharArray();
            char previousCharacter = characters[0];
            bool hasAdjecentSame = false;

            for (var i = 1; i < characters.Length; i++)
            {
                if (previousCharacter > characters[i])
                {
                    return false;
                }
                hasAdjecentSame = previousCharacter == characters[i] || hasAdjecentSame;
                previousCharacter = characters[i];
            }

            return hasAdjecentSame;
        }
    
        public static int CountValidCodes(int lower, int upper)
        {
            int counter = 0;
            for (var code = lower; code <= upper; code++)
            {
                if (IsValid(code))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
