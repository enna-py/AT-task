using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Enums;

namespace BusinessLogic.DriverFactory
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver(BrowserTypes browserType)
        {
            switch (browserType)
            {
                case BrowserTypes.Chrome:
                    return new ChromeDriver();
                case BrowserTypes.FireFox:
                    return new FirefoxDriver();
                case BrowserTypes.Edge:
                    return new EdgeDriver();
                default:
                    throw new ArgumentException("Unsupported browser type: " + browserType);
            }
        }
    }
}
