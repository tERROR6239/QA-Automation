using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V104.Network;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace SeleniumTestsDemoWiki
{
    public class Tests
    {
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();             
        }


        [Test]
        public void Test_Wiki_Title()
        {
            driver.Url = "https://www.wikipedia.org";
            var windowsTitle = driver.Title;

            Assert.That(windowsTitle.Contains("Wikipedia"));
        }

        [Test]
        public void Test_Wiki_SeleniumPage()
        {
            driver.Url = "https://bg.wikipedia.org";
            var searchBox = driver.FindElement(By.Id("searchInput"));
            searchBox.SendKeys("Selenium" + Keys.Enter);
            Thread.Sleep(1000);
            var searchResult = driver.FindElement(By.LinkText("Софтуерно осигуряване на качеството"));
            searchResult.Click();
            var pageTitle = driver.FindElement(By.Id("firstHeading")).Text;
            Assert.That(pageTitle, Is.EqualTo("Софтуерно осигуряване на качеството"));
        }
    }
}