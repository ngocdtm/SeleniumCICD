using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Selenium_Learn.Pages;
using System.Diagnostics.Tracing;
namespace Selenium_Learn.Tests
{
    public class UnitTest1
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://www.google.com.vn/");
            webDriver.Manage().Window.Maximize();
            IWebElement webElement = webDriver.FindElement(By.Name("q"));
            webElement.SendKeys("Selenium");
            webElement.SendKeys(Keys.Return);

        }
        [Test]
        public void EAWebsiteTest()
        {
            //1. create a new instance of selenium web driver
            IWebDriver driver = new ChromeDriver();
            //2.navigate to the url
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            //3. find the login link
            var loginLink = driver.FindElement(By.Id("loginLink"));
            //4. click the login link
            loginLink.Click();

            //,Explicit wait
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(10),
                Message = "Textbox userNsme does not appear during that timeframe"
            };

            driverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            var txtUserName = driverWait.Until(d =>
            {
                var element = driver.FindElement(By.Name("UserName"));
                return (element != null && element.Displayed) ? element : null;
            });

            //6. Typing on the textUserName
            txtUserName.SendKeys("admin");
            //7. Find the Password text box
            var txtPassword = driver.FindElement(By.Id("Password"));
            //8. Typing on the txtPassword
            txtPassword.SendKeys("password");

            //SeleniumCustomMethods.EnterText(driver, By.Name("USerName"), "admin");
            //SeleniumCustomMethods.EnterText(driver, By.Id("Password"), "password");
            //driver.FindElement(By.CssSelector(".btn")).Submit();
            //9. Identify the login button using cssSelector
            var btnLogin = driver.FindElement(By.CssSelector(".btn"));
            //10. click login button
            btnLogin.Click();
        }
        [Test]
        public void TestWithPOM()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            // pom initalization
            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickLogin();

            loginPage.Login("admin", "password");

        }
        [Test]
        public void EAWebsiteTestReductSize()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.FindElement(By.Id("loginLink")).Click();
            driver.FindElement(By.Name("UserName")).SendKeys("admin");
            driver.FindElement(By.Id("Password")).SendKeys("password");
            driver.FindElement(By.CssSelector(".btn")).Submit();
        }
        //[Test]
        //public void WorkingWithAdvanceControls()
        //{
        //    IWebDriver driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("file:///C:/Users/Laptop/Downloads/-%20My%20ASP.NET%20Application.html");

        //    SeleniumCustomMethods.SelectDropdownByText(driver, By.Id("dropdown"), "Option 2");

        //    SeleniumCustomMethods.MultiSelectElements(driver, By.Id("multiselect"), ["multi1", "multi2"]);

        //    var getSelectedOptions = SeleniumCustomMethods.GetAllSelectedList(driver, By.Id("multiselect"));
        //    getSelectedOptions.ForEach(Console.WriteLine);

        //}

    }
}