using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowProject1BDD.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        static IWebDriver driver;
        [Given(@"launch the browser ""([^""]*)""")]
        public void GivenLaunchTheBrowser(string browser)
        {
            if (browser.Equals("chrome"))
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
               
            }
            else {

                Console.WriteLine("browser not found");
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(10);
        }

        [Given(@"navigate to the given url ""([^""]*)""")]
        public void GivenNavigateToTheGivenUrl(string p0)
        {
            driver.Url = p0;
        }

        [When(@"enter valid ""([^""]*)"" and ""([^""]*)""")]
        public void WhenEnterValidAnd(string admin, string p1)
        {
            driver.FindElement(By.Name("username")).SendKeys(admin);
            driver.FindElement(By.Name("password")).SendKeys(p1);
        }

        [When(@"click on the login button")]
        public void WhenClickOnTheLoginButton()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Then(@"user should be in the userdashboard")]
        public void ThenUserShouldBeInTheUserdashboard()
        {
           String currenturl= driver.Url;
            if (currenturl.Contains("dashboard"))
            {

                Console.WriteLine("Test is pass");
            }
            else {

                Console.WriteLine("Test is failed");
            }
            driver.Quit();
        }


    }
}
