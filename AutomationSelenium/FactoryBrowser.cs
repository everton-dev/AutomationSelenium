using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium
{
    public class FactoryBrowser
    {
        public static IWebDriver Instance(ENUMTypeBrowser typeBrowser)
        {
            switch (typeBrowser)
            {
                case ENUMTypeBrowser.Chrome:
                    ChromeOptions oChromeOptions = new ChromeOptions();

                    oChromeOptions.AddArgument("--start-maximized");
                    return new ChromeDriver(@"../../Drivers", oChromeOptions);

                case ENUMTypeBrowser.InternetExplorer:
                    return new InternetExplorerDriver(@"../../Drivers");

                case ENUMTypeBrowser.FireFox:
                    return new FirefoxDriver();

                case ENUMTypeBrowser.Safari:
                    return new SafariDriver(@"../../Drivers");
            }
            return null;
        }
    }
}
