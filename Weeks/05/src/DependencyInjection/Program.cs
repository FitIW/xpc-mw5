using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddSingleton<Dependency>();
        services.AddSingleton<Service>();
        
        // Build ServiceProvider - any registrations after this line will not take effect 
        var serviceProvider = services.BuildServiceProvider();

        var serviceScopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
        
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var service = scope.ServiceProvider.GetRequiredService<Service>();
            
            Console.WriteLine("1. Scope: " + service.Id);
        } // Dispose services when registered as Scoped or Transient
        
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var service = scope.ServiceProvider.GetRequiredService<Service>();
            
            Console.WriteLine("2. Scope: " + service.Id);
        } // Dispose services when registered as Scoped or Transient
    }
}
