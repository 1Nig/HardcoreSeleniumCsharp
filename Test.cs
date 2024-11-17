using OpenQA.Selenium.Chrome;

namespace TestProject_2
{
    class TestProject2
    {
        string test_url = "https://account.proton.me/login";
        string? password { get; set; }
        string? login { get; set; }
        ChromeDriver driver;
        LoginPage loginPage;
        MailPage mailPage;
        NewLetter newLetter;

        [SetUp]
        public void Tests()
        {
            driver = new ChromeDriver("C:\\Users\\37529\\Downloads\\chromedriver-win64\\chromedriver-win64\\");
            loginPage = new LoginPage(driver);
            mailPage = new MailPage(driver);
            newLetter = new NewLetter(driver);
        }

        [Test, Description("Both login and password are correct")]
        [Category("Smoke")]
        public void Test1() // ввод правильного логина и пароля
        {
            password = "Fake_Account1";
            login = "qwefakeaccount@proton.me";
            driver.Url = test_url;
            System.Threading.Thread.Sleep(10000);
            //логинимсчя на почту
            loginPage.EnterLogin(login);
            loginPage.EnterPassword(password);
            loginPage.ClickLoginButton();
            //ждем загрузку страницы и создаем новое письмо
            System.Threading.Thread.Sleep(20000);
            loginPage.ClickMail();
            System.Threading.Thread.Sleep(100000);
            mailPage.ClickNewLetterButton();
            System.Threading.Thread.Sleep(50000);

        }
        [Test, Description("Correct login, but wrong password")]
        [Category("Smoke")]
        public void Test2()// ввод правильного логина, но неправильного пароля
        {
            password = "Fake_Account7";
            login = "qwefakeaccount@proton.me";
            driver.Url = test_url;
            System.Threading.Thread.Sleep(10000);

            loginPage.EnterLogin(login);
            loginPage.EnterPassword(password);
            loginPage.ClickLoginButton();
            System.Threading.Thread.Sleep(20000);
            loginPage.ClickMail();
            System.Threading.Thread.Sleep(100000);
            //ждем загрузку страницы и создаем новое письмо
            mailPage.ClickNewLetterButton();
        }
        [Test, Description("Wrong login, but correct password")]
        [Category("Smoke")]
        public void Test3()// ввод неправильного логина, но правильного пароля
        {
            password = "Fake_Account1";
            login = "qwefakeccount@proton.me";
            driver.Url = test_url;
            System.Threading.Thread.Sleep(10000);
            loginPage.EnterLogin(login);
            loginPage.EnterPassword(password);
            loginPage.ClickLoginButton();
            System.Threading.Thread.Sleep(20000);
            loginPage.ClickMail();
            System.Threading.Thread.Sleep(100000);
            //ждем загрузку страницы и создаем новое письмо
            mailPage.ClickNewLetterButton();
        }
        

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}

