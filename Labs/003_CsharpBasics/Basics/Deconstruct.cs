namespace Basics
{
    public class Deconstruct : ISample
    {
        public void Run()
        {
            var rectangle = new Rectangle(5.5f, 4.5f);
            var (a, b) = rectangle;

            var myStruct = new MyStruct();
            var (age, test) = myStruct;
        }

        public readonly struct MyStruct
        {
            public readonly int Age;
            public readonly float Test;

            public void Deconstruct(out int age, out float test)
            {
                age = Age;
                test = Test;
            }
        }

        public readonly struct Rectangle
        {
            public readonly float Width, Height;

            public Rectangle(float width, float height)
            {
                Width = width;
                Height = height;
            }

            public void Deconstruct(out float width, out float height)
            {
                width = Width;
                height = Height;
            }
        }
    }
}