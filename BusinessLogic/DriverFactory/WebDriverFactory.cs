using BusinessLogic.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace BusinessLogic.DriverFactory
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver(BrowserTypes browserType)
        {
            return browserType switch
            {
                BrowserTypes.Chrome => new ChromeDriver(),
                BrowserTypes.FireFox => new FirefoxDriver(),
                BrowserTypes.Edge => new EdgeDriver(),
                _ => throw new ArgumentException("Unsupported browser type: " + browserType),
            };
        }
    }
}
