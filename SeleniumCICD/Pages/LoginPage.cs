using OpenQA.Selenium;
using Selenium_Learn.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Learn.Pages
{
    public class LoginPage(IWebDriver driver)
    {
        // prior to c#12
        //private readonly IWebDriver driver;

        //public LoginPage(IWebDriver driver)
        //{
        //    this.driver = driver;
        //}

        IWebElement LoginLink => driver.FindElement(By.Id("loginLink"));

        IWebElement TxtUserName => driver.FindElement(By.Id("UserName"));

        IWebElement TxtPassword => driver.FindElement(By.Id("Password"));

        IWebElement BtnLogin => driver.FindElement(By.CssSelector(".btn"));

        IWebElement LnkEmployeeDetails => driver.FindElement(By.LinkText("Employee Details"));

        IWebElement LnkManageUsers => driver.FindElement(By.LinkText("Manage Users"));

        IWebElement LnkLogoff => driver.FindElement(By.LinkText("Log off"));

        public void ClickLogin()
        {
           LoginLink.ClickElement();
        }

        public void Login(string username, string password)
        {
            TxtUserName.EnterText(username);
            TxtPassword.EnterText(password);
            BtnLogin.SubmitElement();
        }

        public (bool employeeDetails, bool manageUsers) IsLoggedIn()
        {
            return (LnkEmployeeDetails.Displayed, LnkManageUsers.Displayed);
        }


    }
}
