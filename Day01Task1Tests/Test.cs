using Day01Task1Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day01Task1Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [DataRow(12, 2)]
        [DataRow(14, 2)]
        [DataRow(1969, 654)]
        [DataRow(100756, 33583)]
        public void CheckIfGivesCorrectSolution(int mass, int expectedAmount)
        {
            Assert.AreEqual(expectedAmount, Solution.Calculate(mass));
        }
    }
}
