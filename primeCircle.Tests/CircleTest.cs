using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
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

        [SetUp]
        public void GetEstimation()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
           // new DriverManager().SetUpDriver(new ChromeConfig());
            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver = new RemoteWebDriver(options);
            driver.Navigate().GoToUrl("https://cloud.google.com");
            Console.WriteLine("the page is opened");
            driver.FindElement(By.XPath("//a[contains(text(),'See all 100+ products')]")).Click();
        }

        [Test]
        public void VerifyVMClass()
        {
            Assert.AreEqual(2, 2, VerifyMessage);
        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Quit();
            Console.WriteLine("the page is closed");
        }
    }
}