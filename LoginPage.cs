using OpenQA.Selenium;

namespace TestProject_2
{
    internal class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Локаторы элементов страницы
        private By loginField = By.XPath("/html/body/div[1]/div[4]/div[1]/main/div[1]/div[2]/form/div[2]/div[1]/div/div/input");
        private By passwordField = By.XPath("//*[@id=\"password\"]");
        private By loginButton = By.XPath("/html/body/div[1]/div[4]/div[1]/main/div[1]/div[2]/form/button");
        private By Mail = By.XPath("/html/body/div[1]/div[4]/div/main/div/div[2]/ul/li[1]/button/div/div[2]");
        // Методы для взаимодействия с элементами страницы
        public void EnterLogin(string login)
        {
            driver.FindElement(loginField).SendKeys(login);
        }
        public void EnterPassword(string password)
        {
            driver.FindElement(passwordField).SendKeys(password);
        }
        public void ClickLoginButton()
        {
            driver.FindElement(loginButton).Click();
        }
        public void ClickMail()
        {
            driver.FindElement(Mail).Click();
        }
    }
}

