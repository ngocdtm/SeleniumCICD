using Selenium_Learn.Pages;
using System.Text.Json;
using FluentAssertions;
using Selenium_Learn.Models;

namespace Selenium_Learn.Tests.Tests;

public class DataDrivenTesting
{
  
    public class NUnitTestDemo
    {
        private IWebDriver _driver;
        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
        }
        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(Login))]
        public void TestWithPOM(LoginModel loginModel)
        {
            // pom initialization
            // arrange
            LoginPage loginPage = new LoginPage(_driver);

            //act
            loginPage.ClickLogin();
            loginPage.Login(loginModel.UserName, loginModel.Password);

            //assert
            Assert.That(loginPage.IsLoggedIn().employeeDetails && loginPage.IsLoggedIn().manageUsers, Is.True, "Login was unsuccessful");
        }
        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(LoginJsonDataSource))]
        public void TestWithPOMUsingFluentAssertion(LoginModel loginModel)
        {
            // pom initialization
            // arrange
            LoginPage loginPage = new LoginPage(_driver);

            //act
            loginPage.ClickLogin();
            loginPage.Login(loginModel.UserName, loginModel.Password);

            var getLoggedIn = loginPage.IsLoggedIn();
            getLoggedIn.employeeDetails.Should().BeTrue();
            getLoggedIn.manageUsers.Should().BeTrue();
           

        }

        [Test]
        [Category("ddt")]
        public void TestWithPOMWithData()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModels = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);

            // pom initalization
            LoginPage loginPage = new LoginPage(_driver);

            loginPage.ClickLogin();
            foreach (var loginModel in loginModels)
            {
               
                loginPage.Login(loginModel.UserName, loginModel.Password);
            }


        }

        public static IEnumerable<LoginModel> Login()
        {
            yield return new LoginModel()
            {
                UserName = "admin",
                Password = "password"
            };
        }

        public static IEnumerable<LoginModel> LoginJsonDataSource()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);

            foreach(var loginData in loginModel)
            {
                yield return loginData;
            }
           
        }

        private void ReadJsonFile()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            Console.WriteLine($"UserName: {loginModel.UserName} Password: {loginModel.Password}");
        }


        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
