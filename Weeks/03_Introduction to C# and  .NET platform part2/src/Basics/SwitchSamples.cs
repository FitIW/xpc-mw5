using System;

namespace Basics
{
    public class SwitchSamples : ISample
    {
        public enum Color
        {
            Red,
            Green,
            Blue,
            Black
        }

        public void Run()
        {
            ClassicSwitch(Color.Blue);
            ClassicSwitch(Color.Black);
            ClassicSwitchInIfElse(Color.Black);
        }

        public string ClassicSwitch(Color color)
        {
            switch (color)
            {
                case Color.Red:
                    return "The color is red";
                case Color.Green:
                    return "The color is green";
                case Color.Blue:
                    return "The color is blue";
                default:
                    return "The color is unknown";
            }
        }
        public string NewSwitch(Color color)
        {
            var result = color switch
            {
                Color.Red => "The color is red",
                Color.Green => "The color is green",
                Color.Blue => "The color is blue",
                _ => "The color is unknown"
            };
            return result;
        }

        public void ClassicSwitchInIfElse(Color color)
        {
            if (color == Color.Red)
                Console.WriteLine("The color is red");
            else if (color == Color.Green)
                Console.WriteLine("The color is green");
            else if (color == Color.Blue)
                Console.WriteLine("The color is blue");
            else
                Console.WriteLine("The color is unknown.");
        }
    }
}