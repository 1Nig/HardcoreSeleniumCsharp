using OpenQA.Selenium;

namespace TestProject_2
{
    public class NewLetter
    {
        private IWebDriver driver;

        // Конструктор класса NewLetter
        public NewLetter(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Локаторы элементов страницы
        private By receiverField = By.XPath("/html/body/div[1]/div[4]/div/div/div/div[1]/div/div[2]/div/div/div/div/div/div/input");
        private By subjectField = By.XPath("/html/body/div[1]/div[4]/div/div/div/div[1]/div/div[3]/div/div/input");
        private By bodyFrame = By.XPath("/html/body/div[1]/div[4]/div/div/div/div/section/div[1]/div[1]/div/div/iframe"); // Локатор iframe для тела письма
        private By bodyField = By.XPath("/ html / body / div[1] / div / div[1] / div[1]");
        private By sendButton = By.XPath("//button[span[text()='Отправить']]");

        // Методы для взаимодействия с элементами страницы
        public void EnterReceiver(string receiver)
        {
            driver.FindElement(receiverField).SendKeys(receiver);
        }

        public void EnterSubject(string subject)
        {
            driver.FindElement(subjectField).SendKeys(subject);
        }

        public void EnterBody(string body)
        {
            // Переключаемся в iframe для ввода текста письма
            driver.SwitchTo().Frame(driver.FindElement(bodyFrame));
            driver.FindElement(bodyField).SendKeys(body);
            // Возвращаемся обратно из iframe
            driver.SwitchTo().DefaultContent();
        }

        public void ClickSendButton()
        {
            driver.FindElement(sendButton).Click();
        }
    }
}
