using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace ApiumSumatorMobileTests
{
    public class SummatorTests
    {
        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;
        private const string AppiumUri = "http://127.0.0.1:4723/wd/hub";
        private const string App = @"C:\Tests\com.example.androidappsummator.apk";

        [OneTimeSetUp]
        public void StartApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", App);
            //options.AddAdditionalCapability("deviceName", "emulator-5554");
            this.driver = new AndroidDriver<AndroidElement>(new Uri(AppiumUri), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [OneTimeTearDown]
        public void CloseApp()
        {
            this.driver.Quit();
        }


        [Test]
        public void Test_SummatorApp_TwoPossitiveValues()
        {
            //Arrange
            var field1 = driver.FindElementById("com.example.androidappsummator:id/editText1");
            field1.Clear();
            field1.SendKeys("5");

            var field2 = driver.FindElementById("com.example.androidappsummator:id/editText2");
            field2.Clear();
            field2.SendKeys("15");

            //Act
            var calcButton = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");
            calcButton.Click();

            var resultField = driver.FindElementById("com.example.androidappsummator:id/editTextSum").Text;

            //Assert
            Assert.That(resultField, Is.EqualTo("20"));

        }

        [Test]
        public void Test_SummatorApp_InvalidData()
        {
            //Arrange
            var field1 = driver.FindElementById("com.example.androidappsummator:id/editText1");
            field1.Clear();
            field1.SendKeys("Invalid");

            var field2 = driver.FindElementById("com.example.androidappsummator:id/editText2");
            field2.Clear();
            field2.SendKeys("Invalid");

            //Act
            var calcButton = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");
            calcButton.Click();

            var resultField = driver.FindElementById("com.example.androidappsummator:id/editTextSum").Text;

            //Assert
            Assert.That(resultField, Is.EqualTo("error"));

        }
    }
}