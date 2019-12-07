using System;

namespace Day04Task2Solution
{
    public static class Solution
    {
        public static bool IsValid(int code)
        {
            char[] characters = code.ToString().ToCharArray();
            char previousCharacter = characters[0];
            bool hasPair = false;
            int consecutive = 1;

            for (var i = 1; i < characters.Length; i++)
            {
                if (previousCharacter > characters[i])
                {
                    return false;
                }

                if (previousCharacter == characters[i])
                {
                    consecutive++;
                }
                else
                {
                    hasPair = consecutive == 2 || hasPair;
                    consecutive = 1;
                }
                previousCharacter = characters[i];
            }

            return hasPair || consecutive == 2;
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
