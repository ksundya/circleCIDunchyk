using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
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
            driver = new ChromeDriver(service, options);
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            Console.WriteLine("start of the test");
           // new DriverManager().SetUpDriver(new ChromeConfig());
           // driver = new ChromeDriver(options);
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