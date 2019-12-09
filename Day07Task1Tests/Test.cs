using Day07Task1Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Day07Task1Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [DataRow(new int[] { 3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0 }, new int[] { 4, 3, 2, 1, 0 }, 43210)]
        [DataRow(new int[] { 3, 23, 3, 24, 1002, 24, 10, 24, 1002, 23, -1, 23, 101, 5, 23, 23, 1, 24, 23, 23, 4, 23, 99, 0, 0 }, new int[] { 0, 1, 2, 3, 4 }, 54321)]
        [DataRow(new int[] { 3, 31, 3, 32, 1002, 32, 10, 32, 1001, 31, -2, 31, 1007, 31, 0, 33, 1002, 33, 7, 33, 1, 33, 31, 31, 1, 32, 31, 31, 4, 31, 99, 0, 0, 0 }, new int[] { 1, 0, 4, 3, 2 }, 65210)]
        public void CheckAmplifiers(int[] program, int[] phases, int expectedResult)
        {
            Assert.AreEqual(expectedResult, Solution.RunAmplifiers(program, 0, phases)[phases.Length - 1].Last());
        }

        [TestMethod]
        [DataRow(new int[] { 3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0 }, 43210)]
        [DataRow(new int[] { 3, 23, 3, 24, 1002, 24, 10, 24, 1002, 23, -1, 23, 101, 5, 23, 23, 1, 24, 23, 23, 4, 23, 99, 0, 0 }, 54321)]
        [DataRow(new int[] { 3, 31, 3, 32, 1002, 32, 10, 32, 1001, 31, -2, 31, 1007, 31, 0, 33, 1002, 33, 7, 33, 1, 33, 31, 31, 1, 32, 31, 31, 4, 31, 99, 0, 0, 0 }, 65210)]
        public void CheckIfGivesCorrectSolution(int[] program, int expectedResult)
        {
            Assert.AreEqual(expectedResult, Solution.FindBestSettings(program, 0, 0, 4));
        }
    }
}
