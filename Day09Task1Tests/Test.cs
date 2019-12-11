using IntcodeInterpreter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Day09Task1Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void CheckIfQuine()
        {
            var program = new long[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 };
            var interpreter = new Interpreter(program);
            interpreter.Run();
            Assert.IsTrue(Enumerable.SequenceEqual(program, interpreter.Output));
        }

        [TestMethod]
        public void CheckIfSupportsLargeNumber()
        {
            var program = new long[] { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 };
            var interpreter = new Interpreter(program);
            interpreter.Run();
            Assert.AreEqual(16, interpreter.Output.First().ToString().Length);
        }

        [TestMethod]
        public void CheckIfReturnsLargeNumber()
        {
            var program = new long[] { 104, 1125899906842624, 99 };
            var interpreter = new Interpreter(program);
            interpreter.Run();
            Assert.AreEqual(program[1], interpreter.Output.First());
        }
    }
}
