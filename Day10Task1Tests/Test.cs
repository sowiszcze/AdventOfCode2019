using Day10Task1Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Day10Task1Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [DataRow(new string[] { ".#..#", ".....", "#####", "....#", "...##" }, 3, 4, 8)]
        [DataRow(new string[] { "......#.#.", "#..#.#....", "..#######.", ".#.#.###..", ".#..#.....", "..#....#.#", "#..#....#.", ".##.#..###", "##...#..#.", ".#....####" }, 5, 8, 33)]
        [DataRow(new string[] { "......#.#.", "#..#.#....", "..#######.", ".#.#.###..", ".#..#.....", "..#....#.#", "#..#....#.", ".##.#..###", "##...#..#.", ".#....####" }, 5, 8, 33)]
        [DataRow(new string[] { "#.#...#.#.", ".###....#.", ".#....#...", "##.#.#.#.#", "....#.#.#.", ".##..###.#", "..#...##..", "..##....##", "......#...", ".####.###." }, 1, 2, 35)]
        [DataRow(new string[] { ".#..#..###", "####.###.#", "....###.#.", "..###.##.#", "##.##.#.#.", "....###..#", "..#.#..#.#", "#..#.#.###", ".##...##.#", ".....#.#.." }, 6, 3, 41)]
        [DataRow(new string[] { ".#..##.###...#######", "##.############..##.", ".#.######.########.#", ".###.#######.####.#.", "#####.##.#.##.###.##", "..#####..#.#########", "####################", "#.####....###.#.#.##", "##.#################", "#####.##.###..####..", "..######..##.#######", "####.##.####...##..#", ".#####..#.######.###", "##...#.##########...", "#.##########.#######", ".####.#.###.###.#.##", "....##.##.###..#####", ".#.#.###########.###", "#.#.#.#####.####.###", "###.##.####.##.#..##" }, 11, 13, 210)]
        public void CheckIfReturnsCorrectPointAndVisibility(string[] map, int pointX, int pointY, int inView)
        {
            var asteroids = Solution.GetAsteroids(map).ToArray();
            var observatories = Solution.GetObservatories(asteroids).ToArray();
            var observatory = Solution.FindObservatoryWithBestVisibility(observatories);

            Assert.AreEqual(pointX, observatory.Asteroid.X);
            Assert.AreEqual(pointY, observatory.Asteroid.Y);
            Assert.AreEqual(inView, observatory.InView);
        }
    }
}
