using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Text.RegularExpressions;
using System.Text;

namespace TFS_CI_WEB_Razor.Test.Selenium
{
    [TestClass]
    public class SeleniumTest
    {
        static IWebDriver driverFF;
        static IWebDriver driverGC;
        static IWebDriver usedDriver; 
        private string baseURL = "http://localhost:8524/";
        private bool acceptNextAlert = true;
        private static string PATH_To_DRIVER_CHROME = @"C:\WorkSpace\CI-TFS\SeleniumDrivers";

        [AssemblyInitialize]
        [Description("Para agregar otro browser es necesario agregar el nuevo driver de selenium")]
        public static void SetUp(TestContext context)
        {
            driverFF = new FirefoxDriver();
            driverGC = new ChromeDriver(PATH_To_DRIVER_CHROME);
        }

        [AssemblyCleanup]
        public static void CleanUp()
        {
            driverFF.Quit();
            driverGC.Quit();
        }


        [TestMethod]
        public void FireFoxFSearchTextTest()
        {
            driverFF.Navigate().GoToUrl("http://google.com");
            driverFF.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
            driverFF.FindElement(By.Id("lst-ib")).SendKeys(Keys.End);
        }


        [TestMethod]
        public void ChromeSearchTextTest()
        {
            driverGC.Navigate().GoToUrl("http://google.com");
            driverGC.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
            driverGC.FindElement(By.Id("lst-ib")).SendKeys(Keys.End);
        }




        [TestMethod]
        [Description("Prueba la suma de numeros en Chrome")]
        public void ChromeSumABTest()
        {
            SumaTest(driverGC);
        }

        [TestMethod]
        [Description("Prueba la suma de numeros en Firefox")]
        public void FirefoxSumABTest()
        {
            SumaTest(driverFF);
        }




        private void SumaTest(IWebDriver Driver)
        {
            usedDriver = Driver;
            usedDriver.Navigate().GoToUrl(baseURL + "/");
            usedDriver.FindElement(By.Id("NumeroA")).Clear();
            usedDriver.FindElement(By.Id("NumeroA")).SendKeys("1");
            usedDriver.FindElement(By.Id("NumeroB")).Clear();
            usedDriver.FindElement(By.Id("NumeroB")).SendKeys("2");
            usedDriver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
            try
            {
                Assert.AreEqual(1, usedDriver.FindElements(By.CssSelector(".container.body-content")).Count);
                const string textSearch = "^[\\s\\S]*El resultado de la suma es 3[\\s\\S]*$";
                bool foundedText = Regex.IsMatch(usedDriver.FindElement(By.CssSelector("BODY")).Text, textSearch);
                Assert.IsTrue(foundedText);
            }
            catch (AssertFailedException e)
            {
                Assert.Fail(e.Message);
            }
            
            
        }

        #region "Private stuff"

        private bool IsElementPresent(By by)
        {
            try
            {
                usedDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                usedDriver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = usedDriver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
        #endregion
    }
}
