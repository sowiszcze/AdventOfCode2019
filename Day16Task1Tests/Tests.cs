using Day16Task1Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Day16Task1Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [DataRow(new int[] { 0, 1, 0, -1 }, "12345678", 1, new int[] { 4, 8, 2, 2, 6, 1, 5, 8 })]
        [DataRow(new int[] { 0, 1, 0, -1 }, "12345678", 2, new int[] { 3, 4, 0, 4, 0, 4, 3, 8 })]
        [DataRow(new int[] { 0, 1, 0, -1 }, "12345678", 3, new int[] { 0, 3, 4, 1, 5, 5, 1, 8 })]
        [DataRow(new int[] { 0, 1, 0, -1 }, "12345678", 4, new int[] { 0, 1, 0, 2, 9, 4, 9, 8 })]
        public void CheckIfCalculatesCorrectly(int[] pattern, string input, int phases, int[] expectedOutput)
        {
            var fft = new FFT(pattern);
            Assert.IsTrue(Enumerable.SequenceEqual(fft.Decode(input, phases), expectedOutput));
        }

        [TestMethod]
        [DataRow(new int[] { 0, 1, 0, -1 }, "80871224585914546619083218645595", 100, new int[] { 2, 4, 1, 7, 6, 1, 7, 6 })]
        [DataRow(new int[] { 0, 1, 0, -1 }, "19617804207202209144916044189917", 100, new int[] { 7, 3, 7, 4, 5, 4, 1, 8 })]
        [DataRow(new int[] { 0, 1, 0, -1 }, "69317163492948606335995924319873", 100, new int[] { 5, 2, 4, 3, 2, 1, 3, 3 })]
        public void CheckFirstEightDigits(int[] pattern, string input, int phases, int[] expectedOutput)
        {
            var fft = new FFT(pattern);
            Assert.IsTrue(Enumerable.SequenceEqual(fft.Decode(input, phases).Take(8), expectedOutput));
        }
    }
}
