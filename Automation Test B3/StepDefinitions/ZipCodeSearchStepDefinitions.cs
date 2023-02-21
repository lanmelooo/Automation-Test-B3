using Automation_Test_B3.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Automation_Test_B3.StepDefinitions 
{
    [Binding]
    public class ZipCodeSearchStepDefinitions :  GlobalVariable
    {        


        [Given(@"access website correios")]
        public void GivenAccessWebsiteCorreios()
        {
            var headlessMode = new ChromeOptions();
            headlessMode.AddArgument("window-size=1366x768");
            headlessMode.AddArgument("disk-cache-size=0");
            headlessMode.AddArgument("headless");

            var devMode = new ChromeOptions();
            devMode.AddArgument("disk-cache-size=0");
            devMode.AddArgument("start-maximized");

            if (headlessTest) { driver = new ChromeDriver(headlessMode); }
            else { driver = new ChromeDriver(devMode); driverQuit = true; }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://www.correios.com.br";
        }

        [When(@"search for non-existent zip code")]
        public void WhenSearchForNon_ExistentZipCode()
        {
            // Non-existent zip code
            driver.FindElement(By.Id("relaxation")).SendKeys("80700000");
            driver.FindElement(By.Id("carol-fecha")).Click();
            driver.FindElement(By.CssSelector("#content > div.mais-acessados > div > div.card-destaque-normal.flex > div:nth-child(2) > form > div.campo > button > i")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Assert.That(driver.FindElement(By.Id("mensagem-resultado-alerta")).Text, Does.Contain("Dados não encontrado"));
        }

        [When(@"search by existing zip code")]
        public void WhenSearchByExistingZipCode()
        {
            // Home page
            driver.FindElement(By.XPath("//*[@id=\"menu\"]/a[2]")).Click();

            // Existing zip code
            driver.FindElement(By.Id("relaxation")).SendKeys("01013001");
            driver.FindElement(By.Id("carol-fecha")).Click();
            driver.FindElement(By.CssSelector("#content > div.mais-acessados > div > div.card-destaque-normal.flex > div:nth-child(2) > form > div.campo > button > i")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[2]);
            Assert.That(driver.FindElement(By.XPath("//*[@id=\'resultado-DNEC\']/tbody/tr/td[1]")).Text, Does.Contain("Rua Quinze de Novembro"));
            Assert.That(driver.FindElement(By.XPath("//*[@id=\'resultado-DNEC\']/tbody/tr/td[3]")).Text, Does.Contain("São Paulo/SP"));
        }

        [When(@"look for tracking code")]
        public void WhenLookForTrackingCode()
        {
            // Home page
            driver.FindElement(By.XPath("//*[@id=\"menu\"]/a[2]")).Click();

            //Tracking
            driver.FindElement(By.Id("objetos")).SendKeys("SS987654321BR");
            driver.FindElement(By.ClassName("ic-busca-out")).Click();
        }

        [Then(@"close browser")]
        public void ThenCloseBrowser()
        {
            if (driverQuit) driver.Quit();
        }
    }
}
