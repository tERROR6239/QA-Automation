using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Security.Cryptography.X509Certificates;

namespace AppiumSumatorMobileTestsLab
{
    public class Tests
    {
        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;
        private const string AppiumUri = "http://127.0.0.1:4723/wd/hub";
        private const string App = @"C:\Tests\com.example.androidappsummator.apk";


        [OneTimeSetUp]
        public void Setup()
        {
            this.options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", App);
            this.driver = new AndroidDriver<AndroidElement>(new Uri(AppiumUri), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        [OneTimeTearDown]
        public void SetupTearDown()
        {
            this.driver.Quit();

        }

        [Test]
        public void TestSummatorApp_TwoPossitiveValues()
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
        }
}