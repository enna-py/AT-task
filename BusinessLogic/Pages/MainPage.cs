using OpenQA.Selenium;

namespace BusinessLogic.Pages
{
    public class MainPage
    {
        private readonly IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement UserNameInput => driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordInput => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("login-button"));
        private IWebElement ErrorMessage => driver.FindElement(By.XPath("//div[contains(@class, 'error-message-container')]//h3[@data-test='error']"));
        
        public void EnterUserName(string userName)
        {
            UserNameInput.SendKeys(userName);
        }

        public void EnterPassword(string password)
        {
            PasswordInput.SendKeys(password);
        }

        public void ClearUserName()
        {
            UserNameInput.SendKeys(Keys.Control + "a");
            UserNameInput.SendKeys(Keys.Delete);

        }

        public void ClearPassword()
        {
            PasswordInput.SendKeys(Keys.Control + "a");
            PasswordInput.SendKeys(Keys.Delete);
        }

        public void PressLoginButton()
        {
            LoginButton.Click();
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }
    }
}
