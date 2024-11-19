using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
//using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;



namespace TestProjectSelenium
{
    [TestClass]
    public class UnitTestWebapp
    {
        private static IWebDriver driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            driver = new FirefoxDriver();
            //driver = new EdgeDriver();
            driver.Navigate().GoToUrl(@"http://127.0.0.1:5500/index.html");

        }

        [ClassCleanup]
        public static void TearDown()
        {

            driver.Quit();
        }

        [TestMethod]
        public void TestButtonExist()
        {
            //driver.Navigate().GoToUrl(@"http://127.0.0.1:5500/end/index.html");
            System.Console.WriteLine("driver url:" + driver.Url);

            IWebElement button = driver.FindElement(By.Id("testButton1"));

            string actualBtnText = button.Text;

            Assert.AreEqual("Click Me", actualBtnText);

            //button.Click();
            // Assert.AreEqual(driver.Url, "https://www.selenium.dev/");
        }
        [TestMethod]
        public void TestButtonHasChangedClassAfterOneClick()
        {
            IWebElement button = driver.FindElement(By.Id("testButton1"));
            button.Click();
            IWebElement button2 = driver.FindElement(By.Id("testButton2"));
            button2.Click();
            //after the click the classattribute should be button1
            string actualClass = button2.GetAttribute("class");

            Assert.AreEqual("button1", actualClass);


        }

    }
}
