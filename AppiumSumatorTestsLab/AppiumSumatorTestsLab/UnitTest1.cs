using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace AppiumSumatorTestsLab
{
    public class Tests
    {
        private WindowsDriver<WindowsElement> driver;
        private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;
        private AppiumLocalService appiumLocal;


        [OneTimeSetUp]
        public void Setup()
        {
            this.options = new AppiumOptions() { PlatformName = "Windows" };
            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Tests\WindowsFormsApp.exe");
            // @"Microsoft.WindowsCalculator_8wekyb3d8bbwe!App"

            driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.CloseApp();
            driver.Quit();
            appiumLocal.Dispose();

        }


        [Test]
        public void Test_Sum_WithTwoPositiveNumbers()
        {
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Clear();
            num1.SendKeys("8");

            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Clear();
            num2.SendKeys("4");

            var buttonCalc = driver.FindElementByAccessibilityId("buttonCalc");
            buttonCalc.Click();

            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;
           
            Assert.That(result,Is.EqualTo("12"));
        }
    }
}