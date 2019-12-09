using Day06Task1Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day06Task2Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void CheckIfGivesCorrectSolution()
        {
            Assert.AreEqual(4, Solution.FindClosestPathLength(new string[] { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L", "K)YOU", "I)SAN" }, "YOU", "SAN"));
        }
    }
}
