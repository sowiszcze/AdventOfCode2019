using Day08Task1Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Day08Task1Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void CheckImageCreation()
        {
            const string input = "123456789012";
            var result = Solution.CreateImage(input, 3, 2);
            Assert.AreEqual(2, result.Length);
            Assert.IsTrue(result.All(r => r.Length == 2 && r.All(c => c.Length == 3)));
        }
    }
}
