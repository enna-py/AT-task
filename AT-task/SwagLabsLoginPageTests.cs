using BusinessLogic.CoreWebDriver;
using BusinessLogic.Enums;
using BusinessLogic.Pages;
using OpenQA.Selenium;

namespace AT_task
{
    public class SwagLabsLoginPageTests
    {
        private MainPage? loginPage;
        private SwagLabs? swagPage;

        [Theory]
        [InlineData(BrowserTypes.Chrome, "username", "password")]
        [InlineData(BrowserTypes.FireFox, "standard_user", "secret_sauce")]
        [InlineData(BrowserTypes.Edge, "standard_user", "secret_sauce")]
        public void LoginForm_WithEmptyCredentials_NotValidInputData(BrowserTypes browserType, string userName, string password)
        {
            try
            {
                IWebDriver driver = DriverInstanceManager.GetDriver(browserType);
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                loginPage = new MainPage(driver);

                loginPage.EnterUserName(userName);
                loginPage.EnterPassword(password);
                loginPage.ClearUserName();
                loginPage.ClearPassword();
                loginPage.PressLoginButton();

                Assert.Equal("Epic sadface: Username is required", loginPage.GetErrorMessage());
            }
            finally
            {
                DriverInstanceManager.QuitDriver();
            }
        }

        [Theory]
        [InlineData(BrowserTypes.Chrome, "username", "password")]
        [InlineData(BrowserTypes.Edge, "standard_user", "secret_sauce")]
        [InlineData(BrowserTypes.FireFox, "standard_user", "secret_sauce")]
        public void LoginForm_WithCredentialsByPassingUserName_NotValidInputData(BrowserTypes browserType, string userName, string password)
        {
            try
            {
                IWebDriver driver = DriverInstanceManager.GetDriver(browserType);
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                loginPage = new MainPage(driver);

                loginPage.EnterUserName(userName);
                loginPage.EnterPassword(password);
                loginPage.ClearPassword();
                loginPage.PressLoginButton();

                Assert.Equal("Epic sadface: Password is required", loginPage.GetErrorMessage());
            }
            finally
            {
                DriverInstanceManager.QuitDriver();
            }
        }

        [Theory]
        [InlineData(BrowserTypes.Chrome, "standard_user", "secret_sauce")]
        [InlineData(BrowserTypes.Edge, "problem_user", "secret_sauce")]
        [InlineData(BrowserTypes.FireFox, "performance_glitch_user", "secret_sauce")]
        [InlineData(BrowserTypes.FireFox, "error_user", "secret_sauce")]
        [InlineData(BrowserTypes.FireFox, "visual_user", "secret_sauce")]
        public void LoginForm_WithCredentialsByPassingUserNameAndPassword_ShouldSuccess(BrowserTypes browserType, string userName, string password)
        {
            try
            {
                IWebDriver driver = DriverInstanceManager.GetDriver(browserType);
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                swagPage = new SwagLabs(driver);
                loginPage = new MainPage(driver);

                loginPage.EnterUserName(userName);
                loginPage.EnterPassword(password);
                loginPage.PressLoginButton();

                Assert.Equal("Swag Labs", swagPage.GetTitle());
            }
            finally
            {
                DriverInstanceManager.QuitDriver();
            }
        }
    }
}