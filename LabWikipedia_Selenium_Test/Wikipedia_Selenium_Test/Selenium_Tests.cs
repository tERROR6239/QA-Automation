using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Wikipedia_Selenium_Test
{
    public class Selenium_Tests
    {
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
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

        [Test]
        public void Test_Wikipedia_Search()
        {

            driver.Url = "https://bg.wikipedia.org";
            var searchBox = driver.FindElement(By.Name("search"));
            searchBox.SendKeys("Selenium" + Keys.Enter);

            var serchResult = driver.FindElement(By.LinkText("Софтуерно осигуряване на качеството"));
            //var serchResult = driver.FindElement(By.PartialLinkText("Софтуерно осигуряване"));
            //var serchResult = driver.FindElement(By.CssSelector("#mw-content-text > div.searchresults > div.mw-search-results-container > ul > li:nth-child(2) > table > tbody > tr > td.searchResultImage-text > div.mw-search-result-heading > a"));
            //var serchResult = driver.FindElement(By.XPath("//*[@id=\"mw-content-text\"]/div[3]/div[2]/ul/li[2]/table/tbody/tr/td[2]/div[1]/a"));
            serchResult.Click();

            //var pageTitle = driver.FindElement(By.ClassName("mw-page-title-main")).Text;
            var pageTitle = driver.FindElement(By.Id("firstHeading")).Text;
            
            Assert.That(pageTitle, Is.EqualTo("Софтуерно осигуряване на качеството"));

        }
    }
}