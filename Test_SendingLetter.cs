using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace TestProject_2
{
    class Test_SendingLetter
    {
        string test_url = "https://account.proton.me/login";
        string? password { get; set; }
        string? login { get; set; }

        ChromeDriver driver;
        LoginPage loginPage;
        MailPage mailPage;
        NewLetter newLetter;
        Settings settings;

        [SetUp]
        public void Tests()
        {
            driver = new ChromeDriver("C:\\Users\\37529\\Downloads\\chromedriver-win64\\chromedriver-win64\\");
            loginPage = new LoginPage(driver);
            mailPage = new MailPage(driver);
            newLetter = new NewLetter(driver);
        }
        [Test]
        [Category("All")]
        public void Test4()// отправка письма
        {
            password = "Fake_Account1";
            login = "qwefakeaccount@proton.me";
            driver.Url = test_url;
            System.Threading.Thread.Sleep(10000);

            loginPage.EnterLogin(login);
            loginPage.EnterPassword(password);
            loginPage.ClickLoginButton();
            System.Threading.Thread.Sleep(20000);
            loginPage.ClickMail();
            System.Threading.Thread.Sleep(15000);//ждем загрузку страницы и создаем новое письмо
            mailPage.ClickNewLetterButton();
            System.Threading.Thread.Sleep(100000);

            newLetter.EnterReceiver("Quessssstion@protonmail.com");//заполняем и отправляем письмо
            newLetter.EnterSubject("Test");
            newLetter.EnterBody("This is a test email.");
            newLetter.ClickSendButton();

            System.Threading.Thread.Sleep(5000);
        }

        [Test]
        [Category("All")]
        public void Test5()
        {
            string password = "Fake_Account2";
            string login = "Quessssstion@protonmail.com";
            driver.Url = test_url;
            System.Threading.Thread.Sleep(10000);

            loginPage.EnterLogin(login);
            loginPage.EnterPassword(password);
            loginPage.ClickLoginButton();
            System.Threading.Thread.Sleep(20000);
            loginPage.ClickMail();
            System.Threading.Thread.Sleep(100000);
            IncomingMails incomingMails = new IncomingMails(driver);

            if (incomingMails.IsUnreadLetterPresent())
            {
                Console.WriteLine("Элемент является непрочитанным.");
                IWebElement LetterIneed = driver.FindElement(By.CssSelector("body > div.app-root > div.flex.flex-row.flex-nowrap.h-full > div > div > div > div.flex.flex-column.flex-1.flex-nowrap.reset4print > div > div > div > main > div > div > div > div > div > div.items-column-list-container.h-full.overflow-auto.flex.flex-column.flex-nowrap.w-full > div > div:nth-child(2) > div"));
                LetterIneed.Click();// заходим в письмо
                System.Threading.Thread.Sleep(5000);

                IWebElement element = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div/div/div[2]/div/div/div/main/div/div/section/div/div[3]/div/div/div/article/div[1]/div[4]/div[2]/button[1]"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
                Thread.Sleep(5000);
                newLetter.EnterBody("111");
                newLetter.ClickSendButton();
                System.Threading.Thread.Sleep(5000);
            }
            else
            {
                Console.WriteLine("!!!ОШИБКА!!!Нужное письмо не отображено как непрочитанное");
            }
        }
        [Test]
        [Category("All")]
        public void Test6() // получение письма и изменение псевдонима
        {
            password = "Fake_Account1";
            login = "qwefakeaccount@proton.me";
            driver.Url = test_url;
            System.Threading.Thread.Sleep(10000);

            // Используем LoginPage для выполнения входа
            LoginPage loginPage = new LoginPage(driver);
            loginPage.EnterLogin(login); // ввод логина
            loginPage.EnterPassword(password); // ввод пароля
            System.Threading.Thread.Sleep(1000);
            loginPage.ClickLoginButton(); // подтверждаем, заходим в почту
            System.Threading.Thread.Sleep(20000);
            loginPage.ClickMail();
            
            System.Threading.Thread.Sleep(100000);

            // Используем IncomingMails для работы с письмами
            IncomingMails incomingMails = new IncomingMails(driver);
            incomingMails.OpenNewNameLetter(); // открываем письмо с новым псевдонимом
            System.Threading.Thread.Sleep(10000); // ждем загрузку страницы

            string NewName = incomingMails.GetMessageFromIframe();
            Console.WriteLine(NewName);

            Settings settings = new Settings(driver);
            settings.OpenSettings();
            settings.OpenAllSettings();
            System.Threading.Thread.Sleep(10000); // ждем загрузку страницы

            settings.OpenAccountSettings();
            settings.ClickNameChangeButton();
            settings.EnterNewName(NewName);
            settings.SaveSettings();
            System.Threading.Thread.Sleep(10000); // ждем загрузку страницы

            string ActualNamE = settings.GetActualName();
            if (ActualNamE == NewName) // уведомление, удалось ли изменить псевдоним
            {
                Console.WriteLine("Поздравляю. Имя изменено!");
            }
            else
            {
                Console.WriteLine("!!! ОШИБКА !!! Имя осталось прежним.");
            }
        }
        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                screenshot.SaveAsFile(fileName);
            }
            driver.Quit();
        }
    }
}
