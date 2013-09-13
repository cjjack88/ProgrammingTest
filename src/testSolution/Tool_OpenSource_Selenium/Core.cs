using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;

namespace Tool_OpenSource_Selenium
{
    class Core
    {
        IWebDriver driver;
        WebDriverWait wait;

        public enum BrowserType
        {
            FIREFOX, IE, CHROME, HTMLUNIT
        }

        public IWebDriver instantiateBrowser(BrowserType browserType, String url)
        {
            driver = getWebDriver(browserType);
            TimeSpan time = new TimeSpan(0, 0, 30);
            wait = new WebDriverWait(driver, time);
            driver.Url = url;

            return driver;
        }

        public IWebDriver getWebDriver(BrowserType browserType)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var driverDirectory = System.IO.Path.GetDirectoryName(path) + @"\Dependencies\";

            switch (browserType)
            {
                case BrowserType.FIREFOX:
                    return new FirefoxDriver();
                case BrowserType.IE:
                    return new InternetExplorerDriver(driverDirectory, new InternetExplorerOptions() { IntroduceInstabilityByIgnoringProtectedModeSettings = true });
                case BrowserType.CHROME:
                    return new ChromeDriver(driverDirectory);
                default:
                    throw new Exception("Browser type unsupported");
            }
        }

        public void Pause(int Seconds)
        {
            Thread.Sleep(Seconds * 1000);
        }
    }
}
