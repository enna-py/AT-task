using BusinessLogic.CoreWebDriver;
using BusinessLogic.Enums;
using BusinessLogic.Pages;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using OpenQA.Selenium;
using Xunit;
using Xunit.Abstractions;
using Serilog;
using FluentAssertions;

namespace AT_task
{
    public class SwagLabsLoginPageTests
    {
        private MainPage? loginPage;
        private SwagLabs? swagPage;
        private static readonly string BaseUrl = "https://www.saucedemo.com/";
        private readonly ILogger? logger;

        public SwagLabsLoginPageTests(ITestOutputHelper output)
        {
            logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.TestOutput(output, Serilog.Events.LogEventLevel.Verbose)
            .CreateLogger();
        }

        [Theory]
        [InlineData(BrowserTypes.Chrome, "username", "password")]
        [InlineData(BrowserTypes.FireFox, "standard_user", "secret_sauce")]
        [InlineData(BrowserTypes.Edge, "standard_user", "secret_sauce")]
        public void LoginForm_WithEmptyCredentials_NotValidInputData(BrowserTypes browserType, string userName, string password)
        {
            logger?.Information("Starting test: LoginForm_WithEmptyCredentials_NotValidInputData with browser {BrowserType}", browserType);
            try
            {
                IWebDriver driver = DriverInstanceManager.GetDriver(browserType);
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(BaseUrl);
                loginPage = new MainPage(driver);

                logger?.Information("Entering data in the password field and the login field. UserName: {0}, Password: {1}", userName, password);
                loginPage.EnterUserName(userName);
                loginPage.EnterPassword(password);
                logger?.Information("Clearing data from the password field and the login field.");
                loginPage.ClearUserName();
                loginPage.ClearPassword();
                loginPage.PressLoginButton();

                loginPage.GetErrorMessage().Should().Be("Epic sadface: Username is required");
                logger?.Information("Test completed successfully");
            }
            catch (Exception ex)
            {
                logger?.Error(ex, "Test failed");
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
            logger?.Information("Starting test: LoginForm_WithCredentialsByPassingUserName_NotValidInputData with browser {BrowserType}", browserType);
            try
            {
                IWebDriver driver = DriverInstanceManager.GetDriver(browserType);
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(BaseUrl);
                loginPage = new MainPage(driver);

                logger?.Information("Entering data in the password field and the login field. UserName: {0}, Password: {1}", userName, password);
                loginPage.EnterUserName(userName);
                loginPage.EnterPassword(password);
                logger?.Information("Clearing data from the password field.");
                loginPage.ClearPassword();
                loginPage.PressLoginButton();

                loginPage.GetErrorMessage().Should().Be("Epic sadface: Password is required");
                logger?.Information("Test completed successfully");
            }
            catch (Exception ex)
            {
                logger?.Error(ex, "Test failed");
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
            logger?.Information("Starting test: LoginForm_WithCredentialsByPassingUserNameAndPassword_ShouldSuccess with browser {BrowserType}", browserType);
            try
            {
                IWebDriver driver = DriverInstanceManager.GetDriver(browserType);
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(BaseUrl);
                swagPage = new SwagLabs(driver);
                loginPage = new MainPage(driver);

                logger?.Information("Entering data in the password field and the login field. UserName: {0}, Password: {1}", userName, password);
                loginPage.EnterUserName(userName);
                loginPage.EnterPassword(password);
                loginPage.PressLoginButton();

                swagPage.GetTitle().Should().Be("Swag Labs");
                logger?.Information("Test completed successfully");
            }
            catch(Exception ex)
            {
                logger?.Error(ex, "Test failed");
            }
            finally
            {
                DriverInstanceManager.QuitDriver();
            }
        }
    }
}