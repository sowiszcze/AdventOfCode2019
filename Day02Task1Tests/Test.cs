using Day02Task1Solution;
using IntcodeInterpreter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Day02Task1Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [DataRow(new long[] { 1, 0, 0, 0, 99 }, new long[] { 2, 0, 0, 0, 99 })]
        [DataRow(new long[] { 2, 3, 0, 3, 99 }, new long[] { 2, 3, 0, 6, 99 })]
        [DataRow(new long[] { 2, 4, 4, 5, 99, 0 }, new long[] { 2, 4, 4, 5, 99, 9801 })]
        [DataRow(new long[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, new long[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 })]
        [DataRow(new long[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 }, new long[] { 3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50 })]
        public void CheckIfGivesCorrectSolution(long[] program, long[] expectedResult)
        {
            var interpreter = new Interpreter(program);
            interpreter.Run();
            interpreter.AssureCompletion();
            Assert.IsTrue(expectedResult.SequenceEqual(interpreter.Memory));
        }
    }
}
