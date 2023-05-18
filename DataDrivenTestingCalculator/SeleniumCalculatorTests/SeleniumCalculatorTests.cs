using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumCalculatorTests
{
    public class Tests
    {
        private ChromeDriver driver;
        //private FirefoxDriver driver;

        [OneTimeSetUp]
        public void OpenAndNavigate()
        {
            this.driver = new ChromeDriver();
            //this.driver = new FirefoxDriver();
            driver.Url = "https://number-calculator.terror6239.repl.co/";
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_Calculator_Addition()
        {
            //Arrange
            var field1 = driver.FindElement(By.Id("number1"));
            var field2 = driver.FindElement(By.Id("number2"));
            var operation = driver.FindElement(By.Id("operation"));
            var calculate = driver.FindElement(By.Id("calcButton"));
            var resultField = driver.FindElement(By.Id("result"));
            var clearField = driver.FindElement(By.Id("resetButton"));

            //Act
            clearField.Click();
            field1.SendKeys("5");
            operation.SendKeys("+");
            field2.SendKeys("6");
            calculate.Click();

            //Assert
            Assert.That(resultField.Text, Is.EqualTo("Result: 11"));

        }

        [Test]
        public void Test_Calculator_Subtraction()
        {
            //Arrange
            var field1 = driver.FindElement(By.Id("number1"));
            var field2 = driver.FindElement(By.Id("number2"));
            var operation = driver.FindElement(By.Id("operation"));
            var calculate = driver.FindElement(By.Id("calcButton"));
            var resultField = driver.FindElement(By.Id("result"));
            var clearField = driver.FindElement(By.Id("resetButton"));

            //Act
            clearField.Click();
            field1.SendKeys("5");
            operation.SendKeys("-");
            field2.SendKeys("6");
            calculate.Click();

            //Assert
            Assert.That(resultField.Text, Is.EqualTo("Result: -1"));

        }

        [Test]
        public void Test_Calculator_Division()
        {
            //Arrange
            var field1 = driver.FindElement(By.Id("number1"));
            var field2 = driver.FindElement(By.Id("number2"));
            var operation = driver.FindElement(By.Id("operation"));
            var calculate = driver.FindElement(By.Id("calcButton"));
            var resultField = driver.FindElement(By.Id("result"));
            var clearField = driver.FindElement(By.Id("resetButton"));

            //Act
            clearField.Click();
            field1.SendKeys("20");
            operation.SendKeys("/");
            field2.SendKeys("5");
            calculate.Click();

            //Assert
            Assert.That(resultField.Text, Is.EqualTo("Result: 4"));

        }

        [Test]
        public void Test_Calculator_Multiplication()
        {
            //Arrange
            var field1 = driver.FindElement(By.Id("number1"));
            var field2 = driver.FindElement(By.Id("number2"));
            var operation = driver.FindElement(By.Id("operation"));
            var calculate = driver.FindElement(By.Id("calcButton"));
            var resultField = driver.FindElement(By.Id("result"));
            var clearField = driver.FindElement(By.Id("resetButton"));

            //Act
            clearField.Click();
            field1.SendKeys("5");
            operation.SendKeys("*");
            field2.SendKeys("5");
            calculate.Click();

            //Assert
            Assert.That(resultField.Text, Is.EqualTo("Result: 25"));

        }

        [Test]
        public void Test_Calculator_InvalidData()
        {
            //Arrange
            var field1 = driver.FindElement(By.Id("number1"));
            var field2 = driver.FindElement(By.Id("number2"));
            var operation = driver.FindElement(By.Id("operation"));
            var calculate = driver.FindElement(By.Id("calcButton"));
            var resultField = driver.FindElement(By.Id("result"));
            var clearField = driver.FindElement(By.Id("resetButton"));

            //Act
            clearField.Click();
            field1.SendKeys("invalid");
            operation.SendKeys("*");
            field2.SendKeys("invalid");
            calculate.Click();

            //Assert
            Assert.That(resultField.Text, Is.EqualTo("Result: invalid input"));

        }

        [Test]
        public void Test_Calculator_Infinity()
        {
            //Arrange
            var field1 = driver.FindElement(By.Id("number1"));
            var field2 = driver.FindElement(By.Id("number2"));
            var operation = driver.FindElement(By.Id("operation"));
            var calculate = driver.FindElement(By.Id("calcButton"));
            var resultField = driver.FindElement(By.Id("result"));
            var clearField = driver.FindElement(By.Id("resetButton"));

            //Act
            clearField.Click();
            field1.SendKeys("Infinity");
            operation.SendKeys("-");
            field2.SendKeys("Infinity");
            calculate.Click();

            //Assert
            Assert.That(resultField.Text, Is.EqualTo("Result: invalid calculation"));

        }
    }
}