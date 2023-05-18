using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace AppiumSumatorTest
{
    public class TestsSummatorAppiumTests
    {
        private WindowsDriver<WindowsElement> driver;
        private const string AppiumServer = "http://[::1]:4723/wd/hub"; //http://127.0.0.1:4723/wd/hub
        private AppiumOptions options;
        private AppiumLocalService appiumLocal;

        [OneTimeSetUp]
        public void OpenApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Windows" };
            //options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Windows");
            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Tests\WindowsFormsApp.exe");
            
            //Start the Appium server as local app
            appiumLocal = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            appiumLocal.Start();

            driver = new WindowsDriver<WindowsElement>(/*new Uri(AppiumServer)*/ appiumLocal, options);
        }
        [OneTimeTearDown]
        public void ShutDdownApp()
        {

            driver.CloseApp();
            driver.Quit();
            appiumLocal.Dispose();
            //this.driver.Quit();
        }


        [Test]
        public void Test_Sum_TwoPositiveNumbers()
        {
            //Find first field, clear it and send value 8.
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Clear();
            num1.SendKeys("8");

            //Find second field clear it and send value 23.
            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Clear();
            num2.SendKeys("23");

            //Click calculate button
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            //Assert the result
            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;

            Assert.That(result, Is.EqualTo("31"));
        }

        [Test]
        public void Test_Sum_InvalidValues()
        {
            //Find first field, click it and send value 5.
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Clear();
            num1.SendKeys("inv");

            //Find second field click it and send value 15.
            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Clear();
            num2.SendKeys("inv2");

            //Click calculate button
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            //Assert the result
            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;

            Assert.That(result, Is.EqualTo("error"));

        }




    }
}