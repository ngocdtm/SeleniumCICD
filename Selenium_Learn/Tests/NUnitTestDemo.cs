using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Edge;
using Selenium_Learn.Driver;
using Selenium_Learn.Pages;
namespace Selenium_Learn.Tests
{
    [TestFixture("admin", "password", DriverType.Edge)]
    public class NUnitTestDemo
    {
        private IWebDriver _driver;
        private readonly string userName;
        private readonly string password;
        private readonly DriverType driverType;

        public string Username { get; }

        public NUnitTestDemo(string userName, string password, DriverType driverType)
        {
            this.userName = userName;
            this.password = password;
            this.driverType = driverType;
        }
        [SetUp]
        public void SetUp()
        {
            _driver = GetDriverType(driverType);
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
            SetupExtentReports();
        }

        private IWebDriver GetDriverType(DriverType driverType)
        {

            return driverType switch
            {
                DriverType.Chrome => new ChromeDriver(),
                DriverType.Edge => new EdgeDriver(),
                _ => _driver
            };
        }

        private void SetupExtentReports()
        {
            var extentReport = new ExtentReports();
            var spark = new ExtentSparkReporter("Test Report.html");
            extentReport.AttachReporter(spark);
            extentReport.AddSystemInfo("OS", "Window 11");
            extentReport.AddSystemInfo("Browser", driverType.ToString());
            var extentTest = extentReport.CreateTest("Login Test with POM").Log(Status.Pass, "Extent Report initialized");
            extentReport.Flush();

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
