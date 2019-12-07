using Day04Task2Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day04Task2Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [DataRow(112233, true)]
        [DataRow(123444, false)]
        [DataRow(111122, true)]
        public void CheckIfGivesCorrectSolution(int code, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, Solution.IsValid(code));
        }
    }
}
