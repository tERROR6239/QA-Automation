using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Wikipedia_Tests
{
    internal class SeleniumTests
    {
        static void Main()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.wikipedia.org");
            Console.WriteLine("Main page title:" + driver.Title);
            var searchBox = driver.FindElement(By.Id("searchInput"));
            Thread.Sleep(1000);
            searchBox.SendKeys("QA" + Keys.Enter);
            //var seachButton = driver.FindElement(By.CssSelector(".pure-button.pure-button-primary-progressive"));
            //seachButton.Click();
            Console.WriteLine("QA page title:" + driver.Title);
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
