using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class IncomingMails
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public IncomingMails(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
    }

    // Локаторы элементов страницы
    private By unreadLetter = By.XPath("//div[contains(@class, 'unread') and .//span[text()='Непрочитанная почта']]");
    private By letterContent = By.CssSelector("body > div.app-root > div.flex.flex-row.flex-nowrap.h-full > div > div > div > div.flex.flex-column.flex-1.flex-nowrap.reset4print > div > div > div > main > div > div > div > div > div > div.items-column-list-container.h-full.overflow-auto.flex.flex-column.flex-nowrap.w-full > div > div:nth-child(2) > div");
    private By sendButton = By.XPath("//button[span[text()='Отправить']]");
    private By newNameLetter = By.XPath("//span[@class='inline-block max-w-full text-ellipsis' and @title='Quessssstion@protonmail.com, qwefakeaccount@proton.me' and contains(., 'Quessssstion@protonmail.com')]");
    private By iframeElement = By.XPath("/html/body/div[1]/div[3]/div/div/div/div[2]/div/div/div/main/div/div/section/div/div[3]/div/div/div/article[2]/div[2]/div/iframe");
    private By messageElement = By.CssSelector("#proton-root > div > div > div:nth-child(1)");

    // Методы для взаимодействия с элементами
        public bool IsUnreadLetterPresent()
    {
        try
        {
            wait.Until(ExpectedConditions.ElementIsVisible(unreadLetter));
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
    public void OpenUnreadLetter()
    {
        driver.FindElement(unreadLetter).Click();
    }
    public void OpenNewNameLetter()
    {
        driver.FindElement(newNameLetter).Click();
    }
    public string GetMessageFromIframe()
    {
        // Переключаемся в iframe
        IWebElement iframe = driver.FindElement(iframeElement);
        driver.SwitchTo().Frame(iframe);

        // Получаем текст сообщения
        IWebElement message = driver.FindElement(messageElement);
        string messageText = message.GetAttribute("innerText");

        // Возвращаемся к основному контенту
        driver.SwitchTo().DefaultContent();

        return messageText;
    }
}
