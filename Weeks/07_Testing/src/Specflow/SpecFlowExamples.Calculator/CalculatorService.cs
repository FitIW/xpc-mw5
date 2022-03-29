namespace SpecFlowExamples.Calculator
{
    public class CalculatorService
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public int Result { get; set; }

        public int AddNumbers() => Result = FirstNumber + SecondNumber;
    }
}
