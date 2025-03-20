using BusinessLogic.DriverFactory;
using BusinessLogic.Enums;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Driver
{
    public class DriverInstanceManager
    {
        private static DriverInstanceManager _instance;
        private IWebDriver _driver;
        private DriverInstanceManager(BrowserTypes browserType)
        {
            _driver = WebDriverFactory.CreateDriver(browserType);
        }

        private static readonly object _lock = new();
        public static DriverInstanceManager Instance(BrowserTypes browserType)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DriverInstanceManager(browserType);
                    }
                }
            }
            return _instance;
        }


        public IWebDriver Driver
        {
            get { return _driver; }
        }

        public void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
                _instance = null;
            }
        }
    }
}
