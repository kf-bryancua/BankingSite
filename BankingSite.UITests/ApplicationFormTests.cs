using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace BankingSite.UITests
{
    [TestFixture]
    public class ApplicationFormTests
    {
        [Test]
        public void ApplicationFormBlankName()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:51357/");

                var inputAirlineRewardNumber = driver.FindElement(By.Id("AirlineRewardNumber"));
                inputAirlineRewardNumber.SendKeys("A1234567");

                var applyButton = driver.FindElement(By.Id("apply"));
                applyButton.Click();

                ReadOnlyCollection<IWebElement> lis = driver.FindElements(By.TagName("li"));
                Assert.IsTrue(lis.Count > 0);
                Assert.IsTrue(lis[0].Text.Equals("Name cannot be blank.", StringComparison.InvariantCulture));                
            }
        }

        [Test]
        public void ApplicationFormBlankAirlineMembershipNumber()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:51357/");

                var inputName = driver.FindElement(By.Id("Name"));
                inputName.SendKeys("Jason");

                var applyButton = driver.FindElement(By.Id("apply"));
                applyButton.Click();

                ReadOnlyCollection<IWebElement> lis = driver.FindElements(By.TagName("li"));
                Assert.IsTrue(lis.Count > 0);
                Assert.IsTrue(lis[0].Text.Equals("Airline membership number is invalid", StringComparison.InvariantCulture));
            }
        }

        [Test]
        public void ApplicationFormAccepted()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:51357/");

                var inputName = driver.FindElement(By.Id("Name"));
                inputName.SendKeys("Jason");

                var inputAge = driver.FindElement(By.Id("Age"));
                inputAge.SendKeys("30");

                var inputAirlineRewardNumber = driver.FindElement(By.Id("AirlineRewardNumber"));
                inputAirlineRewardNumber.SendKeys("A1234567");

                var applyButton = driver.FindElement(By.Id("apply"));
                applyButton.Click();
                
                ReadOnlyCollection<IWebElement> h2s = driver.FindElements(By.TagName("h2"));
                Assert.IsTrue(h2s.Count > 0);
                Assert.IsTrue(h2s[0].Text.Equals("Application Successful", StringComparison.InvariantCulture));
            }
        }

        [Test]
        public void ApplicationFormFailed()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:51357/");

                var inputName = driver.FindElement(By.Id("Name"));
                inputName.SendKeys("Jason");

                var inputAge = driver.FindElement(By.Id("Age"));
                inputAge.SendKeys("10");

                var inputAirlineRewardNumber = driver.FindElement(By.Id("AirlineRewardNumber"));
                inputAirlineRewardNumber.SendKeys("A1234567");

                var applyButton = driver.FindElement(By.Id("apply"));
                applyButton.Click();

                ReadOnlyCollection<IWebElement> h2s = driver.FindElements(By.TagName("h2"));
                Assert.IsTrue(h2s.Count > 0);
                Assert.IsTrue(h2s[0].Text.Equals("Sorry, your application was not successful", StringComparison.InvariantCulture));
            }
        }
    }
}
