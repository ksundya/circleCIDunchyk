using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PrimeCircle;
using System;
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
            new DriverManager().SetUpDriver(new ChromeConfig());
            Thread.Sleep(3000);
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://cloud.google.com");
          //  Thread.Sleep(3000);
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