using OpenQA.Selenium;

namespace BusinessLogic.Pages
{
    public class SwagLabs
    {
        private readonly IWebDriver driver;

        public SwagLabs(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement Title => driver.FindElement(By.ClassName("app_logo"));

        public string GetTitle()
        {
            return Title.Text;
        }
    }
}
