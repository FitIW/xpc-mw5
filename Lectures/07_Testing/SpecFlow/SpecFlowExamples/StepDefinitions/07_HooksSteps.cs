namespace SpecFlowExamples.StepDefinitions
{
    [Binding]
    public class HooksSteps
    {
        [Given("I bring the system to state A")]
        public void SetSystemState() { /* code */ }

        [When("I do some changes to the system")]
        public void DoSomeChangesToTheSystem() { /* code */ }

        [Then("System should be in state B")]
        public void CheckSystemState() { /* code */ }
    }
}
