using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace AutomationTests.Hooks
{
    [Binding]
    public sealed class DriverHooks
    {
        public static RemoteWebDriver Driver { get; set; }

        [BeforeScenario]
        public void OpenBrowser()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
