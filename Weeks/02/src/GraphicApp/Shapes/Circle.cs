namespace GraphicApp.Shapes;

// This class represents circle shape in our application
// It is marked as sealed because it is not supposed to be inherited
// Circle inherits from Shape = Circle is Shape
// Circle implements IDrawable interface = circle implements all the methods from IDrawable interface
public sealed class Circle : Shape, IDrawable
{
    private double _radius;
    private const double Pi = 3.14;

    // We must call base class constructor in Shape class via base keyword
    public Circle(double radius, Color color, Position position) : base(color, position)
    {
        _radius = radius;
    }

    // We must override this method because it is marked as abstract in base class Shape
    public override double GetArea() => Pi * Double.Pow(_radius, 2);

    // We must override this method because it is marked as abstract in base class Shape
    // this keyword in Console.WriteLine translates into this.ToString()
    public override void Draw() => Console.WriteLine($"Drawing {this}");
    
    // ToString method comes from System.Object
    // If we override this method, we specify a new implementation that is used when ToString() method is called on instances of this class
    public override string ToString()
    {
        return $"CIRCLE - color: {Color}, position: ({Position.X},{Position.Y})";
    }
}