using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace TaskBoard.WebDriverTests
{
    public class WebDriverTest
    {
        private const string url = "https://taskboard-1.m33rschaum.repl.co";
        private WebDriver driver;

        [SetUp]
        public void OpenBroser()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void CloseBroser()
        {
            this.driver.Quit();
        }


        [Test]
        public void Test_ListTheTasks_CheckFirstProject()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);
            var contactsLink = driver.FindElement(By.LinkText("Task Board"));

            //Act
            contactsLink.Click();

            //Assert
            var Title = driver.FindElement(By.CssSelector("div:nth-of-type(3) > table:nth-of-type(1)  .title > td")).Text;
            
            Assert.That(Title, Is.EqualTo("Project skeleton"));
           
        }

        [Test]
        public void Test_FindTasks_CheckFirstResult()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);
            var contactsLink = driver.FindElement(By.LinkText("Search"));

            //Act
            contactsLink.Click();
            var serchField = driver.FindElement(By.Id("keyword"));
            serchField.SendKeys("home");
            driver.FindElement(By.Id("search")).Click();

            //Assert
            var Title = driver.FindElement(By.CssSelector(".title > td")).Text;
           

            Assert.That(Title, Is.EqualTo("Home page"));
           
        }

        [Test]
        public void Test_FindTasks_EptyResults()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);
            var contactsLink = driver.FindElement(By.LinkText("Search"));

            //Act
            contactsLink.Click();
            var serchField = driver.FindElement(By.Id("keyword"));
            serchField.SendKeys("missing235435");
            driver.FindElement(By.Id("search")).Click();

            //Assert
            var searchResults = driver.FindElement(By.Id("searchResult")).Text;

            Assert.That(searchResults, Is.EqualTo("No tasks found."));

        }

        [Test]
        public void Test_CreateTask_InvalidData()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);
            var contactsLink = driver.FindElement(By.LinkText("Create"));

            //Act
            contactsLink.Click();
            var firstName = driver.FindElement(By.Id("Title"));
            firstName.SendKeys("");
            driver.FindElement(By.Id("create")).Click();

            //Assert
            var errorMessage = driver.FindElement(By.ClassName("err")).Text; 

            Assert.That(errorMessage, Is.EqualTo("Error: Title cannot be empty!"));

        }

        [Test]
        public void Test_CreateTask_ValidData()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.LinkText("Create")).Click();

            var Title = "Task6240";
            var Description = "alabala";
            var Board = "Done";
            

            //Act
            driver.FindElement(By.Id("title")).SendKeys(Title);
            driver.FindElement(By.Id("description")).SendKeys(Description);
            driver.FindElement(By.Id("boardName")).SendKeys(Board);
           
            driver.FindElement(By.Id("create")).Click();

            //Assert
            var allTasks = driver.FindElements(By.CssSelector("table.task-entry"));
            var lastTask = allTasks.Last();


            var fName = lastTask.FindElement(By.CssSelector("tr.title > td")).Text;
            var lName = lastTask.FindElement(By.CssSelector("tr.description > td")).Text;

            Assert.That(fName, Is.EqualTo(Title));
            Assert.That(lName, Is.EqualTo(Description));

        }


    }
}