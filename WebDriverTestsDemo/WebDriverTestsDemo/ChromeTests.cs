using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


// Create new Chrome browser instance
var driver = new ChromeDriver();

// Navigate to Wikipedia
driver.Url = "https://wikipedia.org";

System.Console.WriteLine("CURRENT TITLE: " + driver.Title);

//locate serch field by ID
var searcField = driver.FindElement(By.Id("searchInput"));

//click on element
searcField.Click();

//fill QA and predd ENTER
searcField.SendKeys("QA" + Keys.Enter);

// Close browser
driver.Quit();
