namespace ReflectionSupportProject
{
    public class Calculator
    {
        public double Number { get; private set; } = 100;

        public static double Pi => 3.1428;

        public void Clear()
        {
            DoClear();
        }

        private void DoClear()
        {
            Number = 0;
        }

        public double Add(double number)
        {
            Number += number;
            return Number;
        }
    }
}