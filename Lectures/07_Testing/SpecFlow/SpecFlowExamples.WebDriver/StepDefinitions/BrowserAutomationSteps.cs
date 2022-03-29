using OpenQA.Selenium;

namespace SpecFlowExamples.WebDriver.StepDefinitions
{
    [Binding]
    public class BrowserAutomationSteps
    {
        private readonly IWebDriver driver;

        public BrowserAutomationSteps(ScenarioContext scenarioContext)
        {
            driver = scenarioContext["driver"] as IWebDriver;
        }

        [Given("I open google chrome")]
        public void OpenGoogleChrome()
        {
            driver.Navigate().GoToUrl(@"https://www.google.com/");
            Thread.Sleep(3000);
        }

        [When("I navigate to VUT website")]
        public void OpenVutWebSite()
        {
            driver.Navigate().GoToUrl(@"https://www.vut.cz/");
            Thread.Sleep(3000);
        }

        [Then("I should see play button")]
        public void SearchForPlayButton()
        {
            var element = driver.FindElement(By.XPath(@"//main[@id='main']//a[@href='#']"));
            Thread.Sleep(3000);
        }
    }
}
