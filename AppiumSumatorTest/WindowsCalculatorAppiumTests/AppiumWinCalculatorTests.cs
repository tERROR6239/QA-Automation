using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace WindowsCalculatorAppiumTests
{
    public class Tests
    {
        private WindowsDriver<WindowsElement> driver;
        private const string AppiumServer = "http://[::1]:4723/wd/hub";
        private AppiumOptions options;
        private AppiumLocalService appiumLocal;

        [OneTimeSetUp] //[SetUp]
        public void OpenApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Windows" };
            //options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Windows");
            options.AddAdditionalCapability(MobileCapabilityType.App, @"Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");

            //Start the Appium server as local app
            //appiumLocal = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            //appiumLocal.Start();

            driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer) /*appiumLocal*/, options);
        }
        [OneTimeTearDown] //[TearDown]
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
            
            var num1 = driver.FindElementByAccessibilityId("num1Button");
            num1.Click();
            var plusButton = driver.FindElementByAccessibilityId("plusButton");
            plusButton.Click();
            var num8 = driver.FindElementByAccessibilityId("num8Button");
            num8.Click();
            
            var calcButton = driver.FindElementByAccessibilityId("equalButton");
            calcButton.Click();

            //Assert the result
            var result = driver.FindElementByAccessibilityId("CalculatorResults").Text;

            Assert.That(result, Is.EqualTo("Display is 9"));
        }

    }
}