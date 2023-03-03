namespace Stack.Exceptions;

public class StackIsFullException : Exception
{
    public StackIsFullException()
    {
    }
    
    public StackIsFullException(string message) : base(message)
    {
    }
    
    public StackIsFullException(string message, Exception inner) : base(message, inner)
    {
    }
}