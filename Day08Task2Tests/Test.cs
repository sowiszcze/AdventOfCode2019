using Day08Task1Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day08Task2Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void CheckFlattening()
        {
            const string input = "0222112222120000";
            var flatImage = Solution.FlattenImage(Solution.CreateImage(input, 2, 2));
            Assert.AreEqual(0, flatImage[0][0]);
            Assert.AreEqual(1, flatImage[0][1]);
            Assert.AreEqual(1, flatImage[1][0]);
            Assert.AreEqual(0, flatImage[1][1]);
        }
    }
}
