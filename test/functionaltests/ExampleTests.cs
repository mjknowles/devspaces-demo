using System;
using Xunit;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.IO;

namespace FunctionalTests
{
    public class ExampleTests : IDisposable
    {
        protected RemoteWebDriver driver;
        protected string browser;

        public ExampleTests()
        {
            //browser = this.TestContext.Properties["browser"] != null ? this.TestContext.Properties["browser"].ToString() : "firefox";
            browser = "chrome";

            switch (browser)
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "chrome":
                    driver = new ChromeDriver(Directory.GetCurrentDirectory());
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                /*case "PhantomJS":
                    driver = new PhantomJSDriver();
                    break;*/
                default:
                    //driver = new PhantomJSDriver();
                    driver = new FirefoxDriver();
                    break;
            }

            /*if (this.TestContext.Properties["Url"] != null) //Set URL from a build
            {
                this.baseURL = this.TestContext.Properties["Url"].ToString();
            }*/
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void AboutPage_Data()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Home/About");
            var text = driver.FindElementByTagName("h3").Text;

            Assert.Equal("Hello from webfrontend and my webapi now says something new", text);
        }
    }
}
