﻿using OpenQA.Selenium.Edge;
using Selenium_Learn.Pages;
namespace Selenium_Learn.Tests
{
    [TestFixture("admin", "password", "chrome")]
    public class NUnitTestDemo
    {
        private IWebDriver _driver;
        private readonly string userName;
        private readonly string password;
        private readonly string driverType;

        public string Username { get; }

        public NUnitTestDemo(string userName, string password, string driverType)
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
        }

        private IWebDriver GetDriverType(string driver)
        {
            if(driver == "chrome")
            {
                _driver = new ChromeDriver();
            }
            else if (driver == "edge")
            {
                _driver = new EdgeDriver();
            }
            return _driver;
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
