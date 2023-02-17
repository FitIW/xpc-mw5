using GraphicApp.Shapes;

namespace GraphicApp;

class Program
{
    public static void RenderShapes(IDrawable[] shapes)
    {
        foreach (IDrawable shape in shapes)
        {
            shape.Draw();
        }
    }
    
    // This is an entry point of this application
    // Main method must be static
    static void Main(string[] args)
    {
        var blueCircle = new Circle(5, Color.Blue, Position.Default());
        var greenCircle = new Circle(10, Color.Green, Position.Default());
        var greenSquare = new Square(2, Color.Green, new(10, 80));

        IDrawable[] shapes = { blueCircle, greenCircle, greenSquare };

        RenderShapes(shapes);
    }
}
