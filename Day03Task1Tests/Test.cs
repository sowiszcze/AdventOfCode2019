using Day03Task1Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day03Task1Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [DataRow("R8,U5,L5,D3", "U7,R6,D4,L4", 6)]
        [DataRow("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [DataRow("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void CheckIfGivesCorrectSolution(string wire1, string wire2, int expectedResult)
        {
            var commands1 = Solution.CreateCommandsList(wire1);
            var commands2 = Solution.CreateCommandsList(wire2);
            var path1 = Solution.CreatePaths(commands1);
            var path2 = Solution.CreatePaths(commands2);
            Assert.AreEqual(expectedResult, Solution.FindIntersections(path1, path2).FindClosest().GetDistance());
        }
    }
}
