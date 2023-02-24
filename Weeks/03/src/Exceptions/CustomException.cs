namespace Exceptions;

public sealed class CustomException : Exception
{
    public CustomException(string message) : base(message)
    {
    }

    public CustomException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static CustomException Create(string message)
    {
        return new CustomException($"Custom exception created using factory method. Message: {message}");
    }
}