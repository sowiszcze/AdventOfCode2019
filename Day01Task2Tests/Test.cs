using Day01Task2Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day01Task2Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [DataRow(14, 2)]
        [DataRow(1969, 966)]
        [DataRow(100756, 50346)]
        public void CheckIfGivesCorrectSolution(int mass, int expectedAmount)
        {
            Assert.AreEqual(expectedAmount, Solution.Calculate(mass));
        }
    }
}
