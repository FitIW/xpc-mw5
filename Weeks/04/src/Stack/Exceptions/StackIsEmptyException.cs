namespace Stack.Exceptions;

public class StackIsEmptyException : Exception
{
    public StackIsEmptyException()
    {
    }

    public StackIsEmptyException(string message) : base(message)
    {
    }

    public StackIsEmptyException(string message, Exception inner) : base(message, inner)
    {
    }
}