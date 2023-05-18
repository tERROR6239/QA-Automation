using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace ContactBook.WebDriverTest
{
    public class UITests
    {
        private const string url = "http://localhost:8080";
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
        public void Test_ListContacts_CheckFirstContact()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);
            var contactsLink = driver.FindElement(By.LinkText("Contacts")); 

            //Act
            contactsLink.Click();

            //Assert
            var firstName = driver.FindElement(By.CssSelector("#contact1 > tbody > tr.fname > td")).Text;
            var lastName = driver.FindElement(By.CssSelector("#contact1 > tbody > tr.lname > td")).Text;

            Assert.That(firstName, Is.EqualTo("Steve"));
            Assert.That(lastName, Is.EqualTo("Jobs"));

        }

        [Test]
        public void Test_SearchContacts_CheckFirstResults()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);
            var contactsLink = driver.FindElement(By.LinkText("Search"));

            //Act
            contactsLink.Click();
            var serchField = driver.FindElement(By.Id("keyword"));
            serchField.SendKeys("Albert");
            driver.FindElement(By.Id("search")).Click();

            //Assert
            var firstName = driver.FindElement(By.CssSelector("#contact3 > tbody > tr.fname > td")).Text;
            var lastName = driver.FindElement(By.CssSelector("#contact3 > tbody > tr.lname > td")).Text;

            Assert.That(firstName, Is.EqualTo("Albert"));
            Assert.That(lastName, Is.EqualTo("Einstein"));

        }

        [Test]
        public void Test_SearchContacts_EmptyResults()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);
            var contactsLink = driver.FindElement(By.LinkText("Search"));

            //Act
            contactsLink.Click();
            var serchField = driver.FindElement(By.Id("keyword"));
            serchField.SendKeys("invalid2635");
            driver.FindElement(By.Id("search")).Click();

            //Assert
            var searchResults = driver.FindElement(By.Id("searchResult")).Text;
            
            Assert.That(searchResults, Is.EqualTo("No contacts found."));
            

        }

        [Test]
        public void Test_CreateContacts_EmptyFiealds()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);
            var contactsLink = driver.FindElement(By.LinkText("Create"));

            //Act
            contactsLink.Click();
            var firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Error");
            driver.FindElement(By.Id("create")).Click();

            //Assert
            var errorMessage = driver.FindElement(By.ClassName("err")).Text; //By.CssSelector("div.err")

            Assert.That(errorMessage, Is.EqualTo("Error: Last name cannot be empty!"));


        }

        [Test]
        public void Test_CreateContacts_ValidData()
        {
            //Arrange
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.LinkText("Create")).Click();

            var firstName = "John" + DateTime.Now.Ticks;
            var lastName = "Doe" + DateTime.Now.Ticks;
            var email = DateTime.Now.Ticks + "test@abv.bg";
            var phone = "12345678";

            //Act
            driver.FindElement(By.Id("firstName")).SendKeys(firstName);
            driver.FindElement(By.Id("lastName")).SendKeys(lastName);
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("phone")).SendKeys(phone);

            driver.FindElement(By.Id("create")).Click();

            //Assert
            var allContacts = driver.FindElements(By.CssSelector("table.contact-entry"));
            var lastContact = allContacts.Last();
            
            
            var fName = lastContact.FindElement(By.CssSelector("tr.fname > td")).Text;
            var lName = lastContact.FindElement(By.CssSelector("tr.lname > td")).Text;

            Assert.That(fName, Is.EqualTo(firstName));
            Assert.That(lName, Is.EqualTo(lastName));


        }


    }
}