using Day18Task1Solution.Enums;

namespace Day18Task1Solution
{
    public static class Extensions
    {
        public static Lock ToLock(this char character)
        {
            return char.IsLetter(character) ? (Lock)(1 << (char.ToLower(character) - 'a')) : Lock.None;
        }
    }
}
