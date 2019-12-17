using Day16Task1Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day16Task2Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [DataRow(new int[] { 0, 1, 0, -1 }, "03036732577212944063491565474664", 100, 8, "84462026")]
        [DataRow(new int[] { 0, 1, 0, -1 }, "02935109699940807407585447034323", 100, 8, "78725270")]
        [DataRow(new int[] { 0, 1, 0, -1 }, "03081770884921959731165446850517", 100, 8, "53553731")]
        public void CheckForCorrectResult(int[] pattern, string encoded, int phases, int length, string expectedResult)
        {
            var fft = new FFT(pattern);
            Assert.AreEqual(expectedResult, fft.FastDecodeWithOffset(encoded, phases, length));
        }
    }
}
