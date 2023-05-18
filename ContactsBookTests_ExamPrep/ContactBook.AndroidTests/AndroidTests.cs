using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace ContactBook.AndroidTests
{
    public class AndroidTests
    {
        private const string AppiumUrl = "http://localhost:4723/wd/hub";
        private const string ContactsBookUrl = "https://contactbook.nakov.repl.co/api";
        //private const string ContactsBookUrl = "http://localhost:8080/api/contacts";
        private const string appLocation = @"C:\Tests\contactbook-androidclient.apk";

        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;

        [SetUp]
        public void StartApp()
        {
            options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", appLocation);

            driver = new AndroidDriver<AndroidElement>(new Uri(AppiumUrl), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
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
            var urlField = driver.FindElement(By.Id("contactbook.androidclient:id/editTextApiUrl"));
            urlField.Clear();
            urlField.SendKeys(ContactsBookUrl);

            var buttonConnect = driver.FindElement(By.Id("contactbook.androidclient:id/buttonConnect"));
            buttonConnect.Click();

            var searchField = driver.FindElement(By.Id("contactbook.androidclient:id/editTextKeyword"));
            searchField.Clear();
            searchField.SendKeys("steve");

            //Act
            var buttonSearch = driver.FindElement(By.Id("contactbook.androidclient:id/buttonSearch"));
            buttonSearch.Click();

            //Assert
            var firstName = driver.FindElement(By.Id("contactbook.androidclient:id/textViewFirstName"));
            var lastName = driver.FindElement(By.Id("contactbook.androidclient:id/textViewLastName"));

            Assert.That(firstName.Text, Is.EqualTo("Steve"));
            Assert.That(lastName.Text, Is.EqualTo("Jobs"));

        }
    }
}