using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverFromExample.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver driver;
        public virtual string PageUrl { get; }
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }
        //Elements
        public IWebElement HomeLink => driver.FindElement(By.LinkText("Home"));
        public IWebElement ViewStudentsLink => driver.FindElement(By.LinkText("View Students"));
        public IWebElement AddStudentsLink => driver.FindElement(By.LinkText("Add Students"));
        public IWebElement PageHeading => driver.FindElement(By.CssSelector("body > h1"));

        //Methods
        public void open()
        {
            driver.Navigate().GoToUrl(this.PageUrl); 
        }

        public bool isOpen()
        {
            return driver.Url == this.PageUrl;
        }

        public string GetPageUrl()
        {
            return driver.Url;
        }

        public string GetPageHeading()
        {
            return PageHeading.Text;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }
    }
}
