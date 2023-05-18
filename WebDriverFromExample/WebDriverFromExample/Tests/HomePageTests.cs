using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverFromExample.Pages;

namespace WebDriverFromExample.Tests
{
    public class HomePageTests
    {
        private IWebDriver driver;



        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
        }

        [TearDown]
        public void ShutDownBrowser()
        {
            driver.Quit();
        }


        [Test]
        public void Test_HomePage_Url_Heading_Title()
        {
            var home_page = new MainPage(driver);
            home_page.open();
            Assert.That(driver.Url, Is.EqualTo(home_page.GetPageUrl()));
            Assert.That(home_page.GetPageHeading(), Is.EqualTo("Students Registry"));
            Assert.That(home_page.GetPageTitle(), Is.EqualTo("MVC Example"));
        }

        [Test]
        public void Test_HomePage_HomeLink()
        {
            var home_page = new MainPage(driver);
            home_page.open();
            home_page.HomeLink.Click();
            Assert.That(home_page.GetPageTitle(), Is.EqualTo("MVC Example"));
            Assert.That(driver.Url, Is.EqualTo(home_page.GetPageUrl()));
        }

        [Test]
        public void Test_HomePage_ViewStudents()
        {
            var home_page = new MainPage(driver);
            home_page.open();
            home_page.ViewStudentsLink.Click();
            var view_sudent = new ViewStudentsPage(driver);
            Assert.That(view_sudent.GetPageTitle, Is.EqualTo("Students"));
            Assert.That(driver.Url, Is.EqualTo(view_sudent.GetPageUrl()));
        }

        [Test]
        public void Test_HomePage_StudentsCount()
        {
            var home_page = new MainPage(driver);
            home_page.open();
            home_page.HomeLink.Click();
            Assert.Greater(home_page.GetStudentCount(), 1);
        }
    }
}
