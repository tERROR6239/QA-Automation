using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumDemoTests
{
    internal class SeleniumTestDemo
    {
        static void Main()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.wikipedia.org");
            Console.WriteLine("Main page title:" + driver.Title);
            var searchBox = driver.FindElement(By.Id("searchInput"));
            searchBox.SendKeys("QA" + Keys.Enter);
            Console.WriteLine("QA page title:" + driver.Title);
            driver.Quit();
        }
    }
}
