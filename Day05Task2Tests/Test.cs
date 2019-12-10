using Day05Task1Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Day05Task2Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [DataRow(new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 8, 1)]
        [DataRow(new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 4, 0)]
        [DataRow(new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 12, 0)]
        [DataRow(new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 4, 1)]
        [DataRow(new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 8, 1)]
        [DataRow(new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 4, 0)]
        [DataRow(new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, 12, 0)]
        [DataRow(new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, 4, 1)]
        [DataRow(new long[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 }, 0, 0)]
        [DataRow(new long[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 }, 1, 1)]
        [DataRow(new long[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 }, 0, 0)]
        [DataRow(new long[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 }, 1, 1)]
        [DataRow(new long[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 }, 4, 999)]
        [DataRow(new long[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 }, 8, 1000)]
        [DataRow(new long[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 }, 12, 1001)]
        public void CheckIfGivesCorrectSolution(long[] program, int input, int expectedResult)
        {
            var result = Solution.Run(program, input);
            if (result.Take(result.Count - 1).Any(r => r != 0))
            {
                Assert.Fail("Not all tests passed.");
            }
            Assert.AreEqual(expectedResult, result.Last());
        }
    }
}
