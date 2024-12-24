using Selenium_Learn.Pages;
namespace Selenium_Learn.Tests
{
    [TestFixture("admin", "password")]
    public class NUnitTestDemo
    {
        private IWebDriver _driver;
        private readonly string userName;
        private readonly string password;

        public string Username { get; }

        public NUnitTestDemo(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestWithPOM()
        {
            // pom initalization
            LoginPage loginPage = new LoginPage(_driver);

            loginPage.ClickLogin();

            loginPage.Login(userName, password);

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
