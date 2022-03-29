using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowExamples.WebDriver.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public void InitializeDriver(ScenarioContext scenarioContext)
        {
            // Create new driver instance
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            // Register driver to built-in SpecFlow dependency injection container
            scenarioContext["driver"] = driver;
        }

        [AfterScenario]
        public void DisposeDriver(ScenarioContext scenarioContext)
        {
            var driver = scenarioContext["driver"] as IWebDriver;

            if (driver != null)
            {
                driver.Dispose();
                driver.Quit();
            }
        }
    }
}
