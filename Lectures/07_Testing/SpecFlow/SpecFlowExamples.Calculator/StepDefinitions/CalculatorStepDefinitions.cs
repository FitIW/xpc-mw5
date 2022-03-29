namespace SpecFlowExamples.Calculator.StepDefinitions
{
    // You can inject services only to classes with [Binding] attribute
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly CalculatorService calculatorService;

        // Constructor dependency injection of CalculatorService
        public CalculatorStepDefinitions(CalculatorService calculatorService)
        {
            this.calculatorService = calculatorService;
        }

        [Given("the first number is (.*)")]
        public void InsertFirstNumber(int number)
        {
            calculatorService.FirstNumber = number;
        }

        [Given("the second number is (.*)")]
        public void InsertSecondNumber(int number)
        {
            calculatorService.SecondNumber = number;
        }

        [When("the two numbers are added")]
        public void AddNumbers()
        {
            calculatorService.AddNumbers();
        }

        [Then("the result should be (.*)")]
        public void CheckResultOfAddition(int result)
        {
            Assert.True(calculatorService.Result == result);
        }
    }
}