namespace GraphicApp;

/// <summary>
/// Data structure which holds a position of a shape on the screen
/// </summary>
public struct Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Static factory method which creates instance of a Position with default values for X and Y
    public static Position Default() => new Position(50, 50);
}