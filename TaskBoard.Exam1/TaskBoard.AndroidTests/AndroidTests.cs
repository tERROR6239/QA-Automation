using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace TaskBoard.AndroidTests
{
    public class AndroidTests
    {
        private const string AppiumUrl = "http://localhost:4723/wd/hub";
        private const string TaskBoardUrl = "https://taskboard-1.m33rschaum.repl.co/api";

        private const string appLocation = @"C:\Tests\taskboard-androidclient.apk";

        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;

        [SetUp]
        public void StartApp()
        {
            options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", appLocation);

            driver = new AndroidDriver<AndroidElement>(new Uri(AppiumUrl), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [TearDown]
        public void CloseApp()
        {
            driver.Quit();
        }



        [Test]
        public void Test_SearchContact_VerifyFirstResult()
        {
            //Arrange
            var urlField = driver.FindElement(By.Id("taskboard.androidclient:id/editTextApiUrl"));
            urlField.Clear();
            urlField.SendKeys(TaskBoardUrl);

            //Act
            var buttonConnect = driver.FindElement(By.Id("taskboard.androidclient:id/buttonConnect"));
            buttonConnect.Click();

            //Assert First title
            var firstTitle = driver.FindElement(By.Id("taskboard.androidclient:id/textViewTitle"));
            Assert.That(firstTitle.Text, Is.EqualTo("Project skeleton"));

            //Act
            var buttonAdd = driver.FindElement(By.Id("taskboard.androidclient:id/buttonAdd"));
            buttonAdd.Click();

            var tName = "Task" + DateTime.Now.Ticks;
            var taskName = driver.FindElement(By.Id("taskboard.androidclient:id/editTextTitle"));
            taskName.Clear();
            taskName.SendKeys(tName);

            var taskDescription = driver.FindElement(By.Id("taskboard.androidclient:id/editTextDescription"));
            taskDescription.Clear();
            taskDescription.SendKeys("alabala");

            var buttonCreate = driver.FindElement(By.Id("taskboard.androidclient:id/buttonCreate"));
            buttonCreate.Click();

            var taskSearch = driver.FindElement(By.Id("taskboard.androidclient:id/editTextKeyword"));
            taskSearch.Clear();
            taskSearch.SendKeys(tName);

            var buttonSearch = driver.FindElement(By.Id("taskboard.androidclient:id/buttonSearch"));
            buttonSearch.Click();

            //Assert
            var taskTitle = driver.FindElement(By.Id("taskboard.androidclient:id/textViewTitle"));
            var taskDescript = driver.FindElement(By.Id("taskboard.androidclient:id/textViewDescription"));

            Assert.That(taskTitle.Text, Is.EqualTo(tName));
            Assert.That(taskDescript.Text, Is.EqualTo("alabala"));

        }

    }
}