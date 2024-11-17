using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestProject_2
{
    public class Settings
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public Settings(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
        // Локаторы элементов страницы
        private By settingsButton = By.XPath("/html/body/div[1]/div[3]/div/div/div/div[2]/div/div/div/header/div[2]/ul/li[2]/button");
        private By allSettingsButton = By.XPath("//*[@id=\"drawer-app-proton-settings\"]/div[2]/div/div[3]/div/div/a[1]");
        private By accountSettings = By.XPath("/html/body/div[1]/div[3]/div/div/div/div[1]/div[4]/nav/ul/ul[1]/li[5]/a");
        private By nameChangeButton = By.XPath("//*[@id=\"account\"]/div[1]/div[2]/div[2]/div/button");
        private By newNameInput = By.XPath("//*[@id=\"displayName\"]");
        private By saveSettingsButton = By.XPath("/html/body/div[4]/dialog/form/div[3]/button[2]");
        private By actualName = By.XPath("//*[@id=\"account\"]/div[1]/div[2]/div[2]/div/div");

        // Методы для взаимодействия с элементами
        public void OpenSettings()
        {
            driver.FindElement(settingsButton).Click();
        }
        public void OpenAllSettings()
        {
            driver.FindElement(allSettingsButton).Click();
        }
        public void OpenAccountSettings()
        {
            driver.FindElement(accountSettings).Click();
        }
        public void ClickNameChangeButton()
        {
            driver.FindElement(nameChangeButton).Click();
        }
        public void EnterNewName(string newName)
        {
            driver.FindElement(newNameInput).SendKeys(newName);
        }
        public void SaveSettings()
        {
            driver.FindElement(saveSettingsButton).Click();
        }
        public string GetActualName()
        {
            return driver.FindElement(actualName).GetAttribute("innerText");
        }
    }
}
