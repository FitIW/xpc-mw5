namespace Exceptions;

class Program
{
    static void A()
    {
        Console.WriteLine("START - A");
        try
        {
            B();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        Console.WriteLine("END - A");
    }

    static void B()
    {
        Console.WriteLine("START - B");
        try
        {
            C();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
            // throw e;
        }
        Console.WriteLine("END - B");
    }

    static void C()
    {
        Console.WriteLine("START - C");
        throw new Exception("Exception from METHOD C");
        Console.WriteLine("END - C");
    }
    
    static void Main(string[] args)
    {
        // Example of control flow when exception is thrown
        Console.WriteLine("START");
        A();
        Console.WriteLine("END");

        // Exception-specific handler
        try
        {
            Method();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void Method()
    {
        // throw new Exception("ORDINARY EXCEPTION");
        throw new ArgumentException("ARGUMENT EXCEPTION");
    }
}
