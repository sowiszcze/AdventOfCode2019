using System;

namespace Day01Task2Solution
{
    public static class Solution
    {
        public static int Calculate(int mass)
        {
            int total = 0;
            int currentMass = mass;
            int currentFuel;
            do
            {
                currentFuel = Normalize(Day01Task1Solution.Solution.Calculate(currentMass));
                currentMass = currentFuel;
                total += currentFuel;
            } while (currentFuel > 0);
            return total;
        }

        private static int Normalize(int mass)
        {
            return Math.Max(mass, 0);
        }
    }
}
