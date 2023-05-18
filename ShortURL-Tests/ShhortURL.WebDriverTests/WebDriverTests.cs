using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace ShhortURL.WebDriverTests
{
    public class WebDriverTests
    {
        private const string url = "http://localhost:8080";
        private WebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        [TearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }


        [Test]
        public void TabelTitle_Test()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);

            //Act
            var TableTitle = driver.FindElement(By.CssSelector("body > main > h1")).Text;

            //Assert
            Assert.That(TableTitle, Is.EqualTo("URL Shortener"));
        }

        [Test]
        public void CreateNewValid_Test()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);
            var AddNewUrl = driver.FindElement(By.LinkText("Add URL"));

            //Act
            AddNewUrl.Click();
            var UrlAdress = driver.FindElement(By.Id("url"));
            UrlAdress.SendKeys("https://tugab.bg");
            var ShortAdress = driver.FindElement(By.Id("code"));
            ShortAdress.Clear();
            ShortAdress.SendKeys("TUGAB");
            driver.FindElement(By.CssSelector("body > main > form > table > tbody > tr:nth-child(3) > td > button")).Click();

            //Assert
            var allUrls = driver.FindElements(By.CssSelector("body > main > table"));
            var lastUrl = allUrls.Last();
            var URLTitle = lastUrl.FindElement(By.CssSelector("tbody > tr:nth-child(4) > td:nth-child(1) > a")).Text;
            Assert.That(URLTitle, Is.EqualTo("https://tugab.bg"));
        }

        [Test]
        public void CreateNewInvalid_Test()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);
            var AddNewUrl = driver.FindElement(By.LinkText("Add URL"));

            //Act
            AddNewUrl.Click();
            var UrlAdress = driver.FindElement(By.Id("url"));
            UrlAdress.SendKeys("");
            var ShortAdress = driver.FindElement(By.Id("code"));
            ShortAdress.Clear();
            ShortAdress.SendKeys("");
            driver.FindElement(By.CssSelector("body > main > form > table > tbody > tr:nth-child(3) > td > button")).Click();

            //Assert
            var errorMesage = driver.FindElement(By.ClassName("err")).Text;
            Assert.That(errorMesage, Is.EqualTo("URL cannot be empty!"));
        }

        [Test]
        public void GotoInvalidUrl_Test()
        {
            //Arrange
            driver.Navigate().GoToUrl(url+ "/go/invalid536524");
           
            //Assert
            var errorMesage = driver.FindElement(By.ClassName("err")).Text;
            Assert.That(errorMesage, Is.EqualTo("Cannot navigate to given short URL"));
        }

        [Test]
        public void VisitsCountIncrease_Test()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);
            var AddNewUrl = driver.FindElement(By.LinkText("Short URLs"));
            AddNewUrl.Click();
            var allUrls = driver.FindElements(By.CssSelector("body > main > table"));
            var lastUrl = allUrls.Last();
            var visitsCount = lastUrl.FindElement(By.CssSelector("tbody > tr:nth-child(4) > td:nth-child(4)")).Text;
            var countOld = Convert.ToInt32(visitsCount);
            //Act
            driver.Navigate().GoToUrl(url + "/go/TUGAB");
            driver.Navigate().GoToUrl(url + "/urls");
            //Assert
            var allUrlss = driver.FindElements(By.CssSelector("body > main > table"));
            var lastUrll = allUrlss.Last();
            var newVisitsCount = lastUrll.FindElement(By.CssSelector("tbody > tr:nth-child(4) > td:nth-child(4)")).Text;
            var countNew = Convert.ToInt32(newVisitsCount); 
            Assert.That(countNew, Is.EqualTo(countOld+1));
        }

    }
}