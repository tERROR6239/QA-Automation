using NUnit.Framework;

namespace SummatorTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int actual = Summator.SummatorApp.Sum(new int[] { 5, 7 });
            int expected = 12;
            Assert.AreEqual(expected, actual);
        }
    }
}