namespace Disposable;

class Program
{
    static void Main(string[] args)
    {
        using (var service = new DisposableService())
        {
            Console.WriteLine("Hello from USING block");
            service.Method();
        }
        
        // Equivalent code
        var s = new DisposableService();
        try
        {
            Console.WriteLine("Hello from TRY block");
            s.Method();
        }
        finally
        {
            if (s is not null)
            {
                s.Dispose();
            }
        }
    }
}
