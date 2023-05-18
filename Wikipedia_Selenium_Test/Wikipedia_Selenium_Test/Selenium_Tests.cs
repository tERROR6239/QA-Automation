using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Wikipedia_Selenium_Test
{
    public class Selenium_Tests
    {
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_Wikipedia_Title()
        {

            driver.Url = "https://www.wikipedia.org";
            var windowsTitle = driver.Title;
            Assert.That(windowsTitle.Contains("Wikipedia"));
        }
    }
}