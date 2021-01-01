using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace MyCSharpTest
{
    [TestFixture]
    public class SeleniumeasyTest
    {
        //   IWebDriver driver = new ChromeDriver("C:\\Users\\Mariya\\chromedriver_win32");
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void initialize()
        {
            driver.Navigate().GoToUrl("https://www.seleniumeasy.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void goToTestNGPageTest()
        {
            IWebElement searchElement = driver.FindElement(By.XPath("//a[text()='TestNG']"));
            searchElement.Click();
            IWebElement currentEl = driver.FindElement(By.CssSelector("#block-easy-breadcrumb-easy-breadcrumb > div > span:nth-child(3) > a"));

            Assert.IsTrue(currentEl.Displayed);
        }

        [Test]
        public void searchTest()
        {
            IWebElement serchElement = driver.FindElement(By.CssSelector("input#edit-search-block-form--2")); ;
            serchElement.SendKeys("selenium");
            serchElement.SendKeys(Keys.Enter);
            string currentUrl = driver.Url;
            Assert.AreEqual("https://www.seleniumeasy.com/search/node/selenium", currentUrl);
        }
        [Test]
        public void scrollDownSeleniumTest()
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            IWebElement element = driver.FindElement(By.XPath("//a[text()='Selenium Tutorials']"));

            je.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
            string currentUrl = driver.Url;
            Assert.AreEqual("https://www.seleniumeasy.com/selenium-tutorials", currentUrl);
        }

        [TearDown]
        public void closepage()

        {
            driver.Close();
            driver.Quit();
        }
}
}
