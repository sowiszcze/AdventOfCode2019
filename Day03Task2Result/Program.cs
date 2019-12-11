using Day03Task2Solution;
using Shared.Helpers;
using System.Linq;

namespace Day03Task2Result
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = Solution.CreateDirectionsList(Data.Wire1);
            var list2 = Solution.CreateDirectionsList(Data.Wire2);
            var wire1 = Solution.CreateWire(list1);
            var wire2 = Solution.CreateWire(list2);
            ConsoleHelper.PrintResult(Solution.GetInterestingIntersectionsLength(wire1, wire2).Min());
        }
    }
}