// Uncomment this line to use hooks
#define USE_HOOKS

#if USE_HOOKS

using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowExamples.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ISpecFlowOutputHelper outputHelper;

        // Using constructor dependency injection to receive ISpecFlowOutputHelper service
        public Hooks(ISpecFlowOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
        }

        // This method must be static!!
        [BeforeTestRun]
        public static void BeforeTestRunLogic() { /* Code */ }

        // This method must be static!!
        [BeforeFeature]
        public static void BeforeFeatureLogic() { /* Code */ }

        [BeforeScenario]
        public void BeforeScenarioLogic(ScenarioContext scenarioContext)
        {
            // You can add anything into ScenarioContext
            scenarioContext["number"] = 1;

            var info = scenarioContext.ScenarioInfo;
            outputHelper.WriteLine($"MY OUTPUT: Title of executed SCENARIO is '{info.Title}'");
        }

        [BeforeStep]
        public void BeforeStepLogic(ScenarioContext scenarioContext)
        {
            // Example of how to obtain data from ScenarioContext
            int number = (int)scenarioContext["number"];

            var info = scenarioContext.StepContext.StepInfo;
            outputHelper.WriteLine($"MY OUTPUT: Title of executed STEP is '{info.Text}'");
        }

        [AfterStep]
        public void AfterStepLogic() { /* Code */ }

        [AfterScenario]
        public void AfterScenarioLogic(ScenarioContext scenarioContext) { /* Code */ }

        // This method must be static!!
        [AfterFeature]
        public static void AfterFeatureLogic(FeatureContext featureContext) { /* Code */ }

        // This method must be static!!
        [AfterTestRun]
        public static void AfterTestRunLogic() { /* Code */ }
    }
}
#endif
