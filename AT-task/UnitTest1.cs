using BusinessLogic.Driver;
using BusinessLogic.DriverFactory;
using BusinessLogic.Enums;
using BusinessLogic.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AT_task
{
    public class UnitTest1
    {
        private MainPage _page;

        [Theory]
        [InlineData(BrowserTypes.Chrome, "none", "none")]
        public void LoginFormWithEmptyCredentials_NotValidInputData(BrowserTypes browserType, string userName, string password)
        {
            IWebDriver driver = DriverInstanceManager.Instance(browserType).Driver;
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _page = new MainPage(driver);
            _page.EnterUserName(userName);
            _page.EnterPassword(password);
            _page.ClearUserName();
            _page.ClearPassword();
            _page.PressLoginButton();
            Assert.Equal("Epic sadface: Username is required", _page.GetErrorMessage());
        }
    }
}