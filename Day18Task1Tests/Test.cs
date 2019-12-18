using Day18Task1Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day18Task1Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [DataRow(new string[] { "#########", "#b.A.@.a#", "#########" }, 8)]
        [DataRow(new string[] { "########################", "#f.D.E.e.C.b.A.@.a.B.c.#", "######################.#", "#d.....................#", "########################" }, 86)]
        [DataRow(new string[] { "########################", "#...............b.C.D.f#", "#.######################", "#.....@.a.B.c.d.A.e.F.g#", "########################" }, 132)]
        [DataRow(new string[] { "########################", "#@..............ac.GI.b#", "###d#e#f################", "###A#B#C################", "###g#h#i################", "########################" }, 81)]
        public void CheckCalculation(string[] tunnels, long expectedValue)
        {
            var vault = new Vault(tunnels);
            Assert.AreEqual(expectedValue, vault.CalculateMinimumStepsForAllKeys());
        }

        [TestMethod]
        [DataRow(new string[] { "#########", "#b.A.@.a#", "#########" }, 8)]
        [DataRow(new string[] { "########################", "#f.D.E.e.C.b.A.@.a.B.c.#", "######################.#", "#d.....................#", "########################" }, 86)]
        [DataRow(new string[] { "########################", "#...............b.C.D.f#", "#.######################", "#.....@.a.B.c.d.A.e.F.g#", "########################" }, 132)]
        [DataRow(new string[] { "#################", "#i.G..c...e..H.p#", "########.########", "#j.A..b...f..D.o#", "########@########", "#k.E..a...g..B.n#", "########.########", "#l.F..d...h..C.m#", "#################" }, 136)]
        [DataRow(new string[] { "########################", "#@..............ac.GI.b#", "###d#e#f################", "###A#B#C################", "###g#h#i################", "########################" }, 81)]
        public void CheckPrecalculation(string[] tunnels, long expectedValue)
        {
            var vault = new Vault(tunnels);
            Assert.AreEqual(expectedValue, vault.FindMinimumStepsForAllKeys());
        }
    }
}
