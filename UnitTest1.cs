using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;



namespace TestProject_2
{
    public class Tests
    {
        public class Browser_ops
        {
            ChromeDriver driver;
            public void Init_Browser()
            {
                driver = new ChromeDriver();
            }
            public void Goto(string test_url)
            {
                driver.Url = test_url;
            }
            public void Close()
            {
                driver.Quit();
            }
            public ChromeDriver getDriver
            {
                get { return driver; }
            }
        }
    }
}