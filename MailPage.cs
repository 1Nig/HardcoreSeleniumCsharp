using OpenQA.Selenium;

namespace TestProject_2
    {
        public class MailPage
        {
            private IWebDriver driver;

            // Конструктор класса MailPage
            public MailPage(IWebDriver driver)
            {
                this.driver = driver;
            }

            // Локаторы элементов страницы
            private By newLetterButton = By.XPath("/html/body/div[1]/div[3]/div/div[2]/div/div[1]/div[2]/button");

            // Методы для взаимодействия с элементами страницы
            public void ClickNewLetterButton()
            {
                driver.FindElement(newLetterButton).Click();
            }
        }
    }

