using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace WebDriverWaitExamples
{
    public class WaitTests
    {
        private WebDriver driver;
        private WebDriverWait wait;

        [TearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_Wait_ThredSleep()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            var element = driver.FindElement(By.PartialLinkText("This is"));

            element.Click();

            Thread.Sleep(15000); //First Strategy

            var text_element = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.IsNotEmpty(text_element);

            ////////////////////////////

            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            var element1 = driver.FindElement(By.PartialLinkText("This is"));

            element1.Click();

            Thread.Sleep(15000);  //First Strategy

            var text_element1 = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.IsNotEmpty(text_element1);
        }


        [Test]
        public void Test_Wait_ImplicitWait()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15); //Second Strategy

            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            driver.FindElement(By.PartialLinkText("This is")).Click();

            var text_element = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.IsNotEmpty(text_element);

            ////////////////////////////

            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            driver.FindElement(By.PartialLinkText("This is")).Click();

            var text_element1 = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.IsNotEmpty(text_element1);
        }

        [Test]
        public void Test_Wait_ExplicitWait()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15)); //Tirth Strategy

            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            driver.FindElement(By.PartialLinkText("This is")).Click();


            //Tirth Strategy
            var text_element = wait.Until(d =>
            {
                return d.FindElement(By.PartialLinkText("This is")).Text;
            });

            Assert.IsNotEmpty(text_element);

            ////////////////////////


            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            driver.FindElement(By.PartialLinkText("This is")).Click();

            var text_element1 = wait.Until(d =>
            {
                return d.FindElement(By.PartialLinkText("This is")).Text;
            });

            Assert.IsNotEmpty(text_element1);
        }

        [Test]
        public void Test_Wait_ExpectedConditions()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15)); //Forth Strategy

            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            driver.FindElement(By.PartialLinkText("This is")).Click();


            //Forth Strategy
            var text_element = wait.Until(
                ExpectedConditions.ElementIsVisible(By.PartialLinkText("This is"))
                );

            Assert.IsNotEmpty(text_element.Text);

            ////////////////////////


            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            driver.FindElement(By.PartialLinkText("This is")).Click();

            var text_element1 = wait.Until(
                ExpectedConditions.ElementIsVisible(By.PartialLinkText("This is"))
                );

            Assert.IsNotEmpty(text_element1.Text);
        }

    }
}