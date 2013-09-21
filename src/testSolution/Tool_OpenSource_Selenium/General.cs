using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Tool_OpenSource_Selenium
{
    [TestClass]
    public class General
    {
        private static IWebDriver _webDriver;
        private TestContext testContextInstance;
        private const string URL = @"https://www.google.com/"; //Targeted URL.

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            _webDriver = new Core().instantiateBrowser(Core.BrowserType.CHROME, URL);
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            _webDriver.Quit();
        }

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void TestGoogle()
        {
            new Core().Pause(3);
            IWebElement login = _webDriver.FindElement(By.Id("gb_2"));
            login.Click();
        }
    }
}
