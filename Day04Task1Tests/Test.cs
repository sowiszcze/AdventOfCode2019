using Day04Task1Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day04Task1Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [DataRow(111111, true)]
        [DataRow(223450, false)]
        [DataRow(123789, false)]
        public void CheckIfGivesCorrectSolution(int code, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, Solution.IsValid(code));
        }
    }
}
