using System.Collections.Concurrent;
using BusinessLogic.DriverFactory;
using BusinessLogic.Enums;
using OpenQA.Selenium;

namespace BusinessLogic.CoreWebDriver
{
    public static class DriverInstanceManager
    {
        private static readonly ConcurrentDictionary<int, IWebDriver> DriverDictionary = [];

        public static IWebDriver GetDriver(BrowserTypes browserType)
        {
            int threadId = Environment.CurrentManagedThreadId;

            return DriverDictionary.GetOrAdd(threadId, _ =>
            {
                return WebDriverFactory.CreateDriver(browserType);
            });
        }
        public static void QuitDriver()
        {
            int threadId = Environment.CurrentManagedThreadId;

            if (DriverDictionary.TryRemove(threadId, out var driver))
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}