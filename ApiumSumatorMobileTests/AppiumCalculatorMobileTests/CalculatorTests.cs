using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace AppiumCalculatorMobileTests
{
    public class CalculatorTests
    {
        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;
        private const string AppiumUri = "http://127.0.0.1:4723/wd/hub";
        private const string App = @"C:\Tests\com.google.android.calculator_8.3.apk";

        [OneTimeSetUp]
        public void StartApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", App);
            this.driver = new AndroidDriver<AndroidElement>(new Uri(AppiumUri), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [OneTimeTearDown]
        public void CloseApp()
        {
            this.driver.Quit();
        }


        [Test]
        public void Test_CalculatorApp_SumTwoValues()
        {
            //Arrange
            var clearr = driver.FindElementById("com.google.android.calculator:id/clr");
            clearr.Click();

            var digit1 = driver.FindElementById("com.google.android.calculator:id/digit_5");
            digit1.Click();

            var operation = driver.FindElementById("com.google.android.calculator:id/op_add");
            operation.Click();

            var digit2 = driver.FindElementById("com.google.android.calculator:id/digit_1");
            digit2.Click();
            var digit3 = driver.FindElementById("com.google.android.calculator:id/digit_5");
            digit3.Click();

            //Act
            var calcButton = driver.FindElementById("com.google.android.calculator:id/eq");
            calcButton.Click();

            var resultField = driver.FindElementById("com.google.android.calculator:id/result_final").Text;

            //Assert
            Assert.That(resultField, Is.EqualTo("20"));

        }

        [Test]
        public void Test_CalculatorApp_MulTwoValues()
        {
            //Arrange
            var clearr = driver.FindElementById("com.google.android.calculator:id/clr");
            clearr.Click();

            var digit1 = driver.FindElementById("com.google.android.calculator:id/digit_5");
            digit1.Click();

            var operation = driver.FindElementById("com.google.android.calculator:id/op_mul");
            operation.Click();

            var digit2 = driver.FindElementById("com.google.android.calculator:id/digit_2");
            digit2.Click();
            var digit3 = driver.FindElementById("com.google.android.calculator:id/digit_5");
            digit3.Click();

            //Act
            var calcButton = driver.FindElementById("com.google.android.calculator:id/eq");
            calcButton.Click();

            var resultField = driver.FindElementById("com.google.android.calculator:id/result_final").Text;

            //Assert
            Assert.That(resultField, Is.EqualTo("125"));

        }

        [Test]
        public void Test_CalculatorApp_FaktTwoValues()
        {
            //Arrange
            var clearr = driver.FindElementById("com.google.android.calculator:id/clr");
            clearr.Click();

            var digit1 = driver.FindElementById("com.google.android.calculator:id/digit_5");
            digit1.Click();

            var operation = driver.FindElementById("com.google.android.calculator:id/op_fact");
            operation.Click();

            //Act
            var calcButton = driver.FindElementById("com.google.android.calculator:id/eq");
            calcButton.Click();

            var resultField = driver.FindElementById("com.google.android.calculator:id/result_final").Text;

            //Assert
            Assert.That(resultField, Is.EqualTo("120"));
        }

        [Test]
        public void Test_CalculatorApp_DivZero()
        {
            //Arrange
            var clearr = driver.FindElementById("com.google.android.calculator:id/clr");
            clearr.Click();

            var digit1 = driver.FindElementById("com.google.android.calculator:id/digit_5");
            digit1.Click();

            var operation = driver.FindElementById("com.google.android.calculator:id/op_div");
            operation.Click();

            var digit2 = driver.FindElementById("com.google.android.calculator:id/digit_0");
            digit2.Click();

            //Act
            var calcButton = driver.FindElementById("com.google.android.calculator:id/eq");
            calcButton.Click();

            var resultField = driver.FindElementById("com.google.android.calculator:id/result_preview").Text;

            //Assert
            Assert.That(resultField, Is.EqualTo("Can't divide by 0"));

        }
    }
}