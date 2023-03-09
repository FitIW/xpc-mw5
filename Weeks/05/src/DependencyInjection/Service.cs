namespace DependencyInjection;

public class Service : IDisposable
{
    private readonly Dependency _dependency;

    public Service(Dependency dependency)
    {
        _dependency = dependency;
    }
    
    public Guid Id { get; } = Guid.NewGuid();
    
    // Dispose method is called automatically by IoC container when service should be destroyed
    public void Dispose()
    {
        Console.WriteLine($"Disposing service {Id}");
    }
}