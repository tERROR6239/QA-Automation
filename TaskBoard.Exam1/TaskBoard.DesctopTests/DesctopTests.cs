using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace TaskBoard.DesktopTests
{
    public class DesktopTest

    {
        private const string AppiumUrl = "http://localhost:4723/wd/hub";
        private const string TaskBoardUrl = "http://localhost:8080/api";
        private const string appLocation = @"C:\Tests\TaskBoardDC\TaskBoard.DesktopClient.exe";

        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions options;

        [SetUp]
        public void StartApp()
        {
            options = new AppiumOptions() { PlatformName = "Windows" };
            options.AddAdditionalCapability("app", appLocation);

            driver = new WindowsDriver<WindowsElement>(new Uri(AppiumUrl), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void CloseApp()
        {
            driver.Quit();
        }

        [Test]
        public void Test_SearchContact_VerifyFirstResult_Desktop()
        {
            //Arrange
            var urlField = driver.FindElementByAccessibilityId("textBoxApiUrl");
            urlField.Clear();
            urlField.SendKeys(TaskBoardUrl);

            //Act
            var buttonConnect = driver.FindElementByAccessibilityId("buttonConnect");
            buttonConnect.Click();

            //Assert First title
            var assertItem = driver.FindElementsByAccessibilityId("listViewTasks");

            foreach (var task in assertItem)
            {
                if (task.Text.StartsWith("Project"))
                {
                    Assert.That(task.Text, Is.EqualTo("Project skeleton"));
                    break;
                }
            }

            //Act
            var buttonAdd = driver.FindElementByAccessibilityId("buttonAdd");
            buttonAdd.Click();

            var tName = "Task" + DateTime.Now.Ticks;
            var taskName = driver.FindElementByAccessibilityId("textBoxTitle");
            taskName.Clear();
            taskName.SendKeys(tName);

            var taskDescription = driver.FindElementByAccessibilityId("textBoxDescription");
            taskDescription.Clear();
            taskDescription.SendKeys("alabala");

            var buttonCreate = driver.FindElementByAccessibilityId("buttonCreate");
            buttonCreate.Click();

            var taskSearch = driver.FindElementByAccessibilityId("textBoxSearchText");
            taskSearch.Clear();
            taskSearch.SendKeys(tName);

            var buttonSearch = driver.FindElementByAccessibilityId("buttonSearch");
            buttonSearch.Click();

            //Assert
            var assertNewItem = driver.FindElementsByAccessibilityId("listViewTasks");

            foreach (var task in assertNewItem)
            {
                if (task.Text.StartsWith("Task"))
                {
                    Assert.That(task.Text, Is.EqualTo(tName));
                    break;
                }
            }
        }
    }
}
