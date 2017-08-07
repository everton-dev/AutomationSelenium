using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium
{
    public class InitAutomation
    {

        private IWebDriver Driver { get; set; }
        private String WindowsDefault { get; set; }

        public InitAutomation()
        {
            ENUMTypeBrowser typeBrowser;

            typeBrowser = (ENUMTypeBrowser) Enum.Parse(typeof(ENUMTypeBrowser), System.Configuration.ConfigurationManager.AppSettings["TYPE_BROWSER"]);

            this.Driver = FactoryBrowser.Instance(typeBrowser);

            if (Driver.WindowHandles.Count > 0)
            {
                this.Driver.SwitchTo().Window(this.Driver.WindowHandles[1]).Close();
                this.Driver.SwitchTo().Window(this.Driver.WindowHandles[0]);
            }

            this.WindowsDefault = this.Driver.CurrentWindowHandle;
        }

        public void Start()
        {
            IWebElement query = null;
            IReadOnlyCollection<IWebElement> rocListQuery = null;
            List<IWebElement> listQuery = null;

            Console.WriteLine("Navigate to Google.");
            this.Driver.Navigate().GoToUrl("http://www.google.com.br");

            Console.WriteLine("Typing Selenium to search...");
            query = this.Driver.FindElement(By.Id("lst-ib"));
            query.SendKeys("Selenium");
            query.SendKeys(OpenQA.Selenium.Keys.Enter);

            rocListQuery = this.Driver.FindElements(By.XPath("//h3[@class='r']"));
            if (rocListQuery != null)
                listQuery = rocListQuery.ToList();
            else
                return;

            Console.WriteLine("Listing...");
            foreach (IWebElement item in listQuery)
            {
                Console.WriteLine(item.Text);
            }

            Console.WriteLine(string.Format("Access the link {0}", listQuery[0].Text));

            query = listQuery[0].FindElement(By.TagName("a"));
            query.Click();

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();

            query = this.Driver.FindElement(By.Id("mainContent"));
            Console.WriteLine(query.Text);

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Closing Driver...");
            this.Driver.Quit();
            this.Driver.Dispose();
            this.Driver = null;

            GC.Collect();
        }
    }
}
