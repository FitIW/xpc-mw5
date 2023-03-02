namespace Disposable;

public sealed class DisposableService : IDisposable
{
    public DisposableService()
    {

    }
    
    // Dispose method is called when exception in this method is thrown
    public void Method()
    {
        throw new Exception();
    }
    
    public void Dispose()
    {
        Console.WriteLine("I am disposing...");
    }
}