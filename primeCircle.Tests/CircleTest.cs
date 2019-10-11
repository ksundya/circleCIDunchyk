using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PrimeCircle;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace PrimeCircle.Tests
{
 [TestFixture]
    public class Tests
    {
        
        private const string VerifyMessage = "The assertion has failed";
        IWebDriver driver;
        String actualResult;

        [SetUp]
        public void GetEstimation()
        {
            String driverPath = "/opt/selenium/";
            String driverExecutableFileName = "chromedriver";
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("headless");
            options.AddArguments("no-sandbox");
            options.BinaryLocation = "/opt/google/chrome/chrome";
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(driverPath, driverExecutableFileName);
            driver = new ChromeDriver(service, options, TimeSpan.FromSeconds(30));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
          //  driver.Manage().Window.Maximize();
            Console.WriteLine("start of the test");
          //  ChromeOptions options = new ChromeOptions();
           // options.AddArgument("--headless");
            // new DriverManager().SetUpDriver(new ChromeConfig());
            // IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            // driver = new ChromeDriver(options);
           // driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            driver.Navigate().GoToUrl("https://cloud.google.com");
            Console.WriteLine("the page is opened");
            IWebElement webElement = driver.FindElement(By.XPath("//a[contains(text(),'See all 100+ products')]"));
            actualResult = webElement.Text;
            webElement.Click();
        }

        [Test]
        public void VerifyVMClass()
        {
            Assert.AreEqual(actualResult, "See all 100+ products", VerifyMessage);
        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Quit();
            Console.WriteLine("the page is closed");
        }
    }
}