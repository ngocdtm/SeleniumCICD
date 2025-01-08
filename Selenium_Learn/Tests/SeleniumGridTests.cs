using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using Selenium_Learn.Driver;
using Selenium_Learn.Pages;

namespace Selenium_Learn.Tests;

    [TestFixture("admin", "password", DriverType.Edge)]
    public class SeleniumGridTests
    {
        private IWebDriver _driver;
        private readonly string userName;
        private readonly string password;
        private readonly DriverType driverType;

        public string Username { get; }

        public SeleniumGridTests(string userName, string password, DriverType driverType)
        {
            this.userName = userName;
            this.password = password;
            this.driverType = driverType;
        }
        [SetUp]
        public void SetUp()
        {
            _driver = new RemoteWebDriver(new Uri("http://localhost:4444"), new FirefoxOptions());
            _driver.Navigate().GoToUrl("http://eaapp.somee.com");
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

