namespace GraphicApp.Shapes;

public sealed class Square : Shape, IDrawable
{
    private double _side;

    public Square(double side, Color color, Position position) : base(color, position)
    {
        _side = side;
    }
    
    public override double GetArea() => _side * _side;

    public override void Draw() => Console.WriteLine($"Drawing {this}");

    public override string ToString()
    {
        return $"SQUARE - color: {Color}, position: ({Position.X},{Position.Y})";
    }
}