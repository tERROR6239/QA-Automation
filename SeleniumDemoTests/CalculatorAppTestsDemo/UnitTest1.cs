using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CalculatorAppTestsDemo
{
    public class Tests
    {
        private ChromeDriver driver;

        IWebElement field1;
        IWebElement field2;
        IWebElement operation;
        IWebElement calculate;
        IWebElement resultField;
        IWebElement clearField;


        [OneTimeSetUp]
        public void OpenAndNavigate()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");

            this.driver = new ChromeDriver(options);
            driver.Url = "https://number-calculator.terror6239.repl.co/";
            field1 = driver.FindElement(By.Id("number1"));
            field2 = driver.FindElement(By.Id("number2"));
            operation = driver.FindElement(By.Id("operation"));
            calculate = driver.FindElement(By.Id("calcButton"));
            resultField = driver.FindElement(By.Id("result"));
            clearField = driver.FindElement(By.Id("resetButton"));

        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            driver.Quit();
        }


        [TestCase("5", "6", "-", "Result: -1")]
        [TestCase("15", "6", "+", "Result: 21")]
        [TestCase("15", "5", "/", "Result: 3")]
        [TestCase("20", "0", "/", "Result: Infinity")]
        [TestCase("15", "2", "*", "Result: 30")]
        [TestCase("alabala", "alabala", "-", "Result: invalid input")]
        [TestCase("Infinity", "Infinity", "-", "Result: invalid calculation")]

        public void TestCalculatorResults(string num1, string num2, string operatio, string result)
        {
            //Act
            field1.SendKeys(num1);
            operation.SendKeys(operatio);
            field2.SendKeys(num2);

            calculate.Click();

            Assert.That(result, Is.EqualTo(resultField.Text));

            clearField.Click();

        }
    }
}