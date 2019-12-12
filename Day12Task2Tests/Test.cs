using Day12Task1Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day12Task2Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [DataRow(new string[] { "<x=-1, y=0, z=2>", "<x=2, y=-10, z=-7>", "<x=4, y=-8, z=8>", "<x=3, y=5, z=-1>" }, 2772)]
        [DataRow(new string[] { "<x=-8, y=-10, z=0>", "<x=5, y=5, z=10>", "<x=2, y=-7, z=3>", "<x=9, y=-8, z=-3>" }, 4686774924)]
        public void CheckIfGivesCorrectAnswer(string[] moons, long expectedResult)
        {
            Assert.AreEqual(expectedResult, Solution.CalculateLoopSteps(moons));
        }
    }
}
