using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace AutomationTests.Hooks
{
    [Binding]
    public sealed class DriverHooks
    {
        /// <summary>
        /// RemoteWebDriver is a concrete class that implements interface WebDriver. 
        /// RemoteWebDriver class contains additional methods that are not declared by interface WebDriver
        /// </summary>
        public static RemoteWebDriver Driver { get; set; }

        [BeforeScenario]
        public void OpenBrowser()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
