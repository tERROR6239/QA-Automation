using NUnit.Framework;
using System;
using System.Linq;

namespace Summator.Tests
{
    public class SummatorTests
    {
        [SetUp]
        public void SetUp()
        {
            System.Console.WriteLine("Test started: " + DateTime.Now);
        }


        [Test]
        public void Test_Sum_TwoPossitiveNumbers()
        {
            int actual = Summator.Sum(new int[] { 5, 7 });
            int expected = 12;
            Assert.That(expected == actual);
        }


        [Test]
        public void Test_Sum_OnePossitiveNumber()
        {
            int actual = Summator.Sum(new int[] { 5 });
            int expected = 5;
            Assert.That(expected == actual);
        }

        [Test]
        public void Test_Sum_TwoNegativeNumbers()
        {
            int actual = Summator.Sum(new int[] { -5, -7 });
            int expected = -12;
            Assert.That(expected == actual);
        }


        [Test]
        public void Test_Sum_EmptyArray()
        {
            int actual = Summator.Sum(new int[] { });
            int expected = 0;
            Assert.That(expected == actual);
        }

        [Test]
        public void Test_Sum_BigValues()
        {
            int actual = Summator.Sum(new int[] { 2000000000, 2000000000, 2000000000 });
            //int expected = 8000000000;
            Assert.AreEqual(6000000000, actual);
        }

        [Test]
        [Category ("Critical")]
        public void Test_Average_TwoPossitiveNumbers()
        {
            int actual = Summator.Average(new int[] { 5, 7 });
            int expected = 6;
            Assert.That(expected == actual);
        }

        [Test]
        [Category("Assert")]
        public void Test_Assertions()
        {
            var values = new int[] { 5, 7 };
            int actual = Summator.Sum(values);
            int expected = 12;
            Assert.That(expected == actual, "Sumator value should be equal to 12");
            Assert.That(expected, Is.EqualTo(actual));
            Assert.AreEqual(expected, actual);

            int percentage = 99;
            Assert.That(percentage, Is.InRange(80, 100));

            Assert.That("QA are awsome", Does.Contain("awsome"));

            string date = "7/11/2021";
            Assert.That(date, Does.Match(@"^\d{1,2}/\d{1,2}/\d{4}$"));

            Assert.That(() => "abv"[10], Throws.InstanceOf<IndexOutOfRangeException>());

            Assert.That(Enumerable.Range(1, 100), Has.Member(55));

        }

        [TearDown]
        public void TearDown()
        {
            System.Console.WriteLine("Test ended: " + DateTime.Now);
        }


    }   

}