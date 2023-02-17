namespace GraphicApp;

/// <summary>
/// Abstract base class for all shapes in our application
/// You cannot create and instance of this class
/// </summary>
public abstract class Shape
{
    // Unique identifier of a shape
    public uint Id { get; }
    public Color Color { get; set; }
    public Position Position { get; set; }

    // Static property used to generate unique value for Id property
    private static uint _instanceCounter;

    // Private constructor which is not supposed to be called from outside of this class
    // It is supposed to be called by all public constructors to perform Id initialization logic
    private Shape()
    {
        _instanceCounter++;
        Id = _instanceCounter;
    }
    
    // Public constructor with two parameters
    // Before it's body is executed, it calls private constructor Shape() via this keyword
    public Shape(Color color, Position position) : this()
    {
        Position = position;
        Color = color;
    }
    
    // These methods two must be implemented by all derived classes
    public abstract double GetArea();
    public abstract void Draw();
}