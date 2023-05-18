
using OpenQA.Selenium;

namespace WebDriverFromExample.Pages
{
    public class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {
        }
        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/students";

        //public IWebElement SudentCount => driver.FindElement(By.CssSelector("body > p > b"));

        /*public int GetStudentCount()
        {
            return int.Parse(SudentCount.Text);
        }
        */

    }
}
