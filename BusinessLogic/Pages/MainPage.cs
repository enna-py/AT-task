using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Pages
{
    public class MainPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement userNameInput => driver.FindElement(By.Id("user-name"));
        private IWebElement passwordInput => driver.FindElement(By.Id("password"));
        private IWebElement loginButton => driver.FindElement(By.Id("login-button"));
        private IWebElement errorMessage => driver.FindElement(By.XPath("//div[contains(@class, 'error-message-container')]//h3[@data-test='error']"));
        
        public void EnterUserName(string userName)
        {
            userNameInput.SendKeys(userName);
        }

        public void EnterPassword(string password)
        {
            passwordInput.SendKeys(password);
        }

        public void ClearUserName()
        {
            userNameInput.SendKeys(Keys.Control + "a");
            userNameInput.SendKeys(Keys.Delete);

        }

        public void ClearPassword()
        {
            passwordInput.SendKeys(Keys.Control + "a");
            passwordInput.SendKeys(Keys.Delete);
        }

        public void PressLoginButton()
        {
            loginButton.Click();
        }

        public string GetErrorMessage()
        {
            return errorMessage.Text;
        }
    }
}
