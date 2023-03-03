using System.Diagnostics;

namespace Cooking;

static class Program
{
    static async Task Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        Console.WriteLine("Preparing breakfast...");
        
        SyncVersion.Run();
        // await AsyncSlowVersion.RunAsync();
        // await AsyncFastVersion.RunAsync();
        
        Console.WriteLine("Breakfast is ready!");
        
        stopwatch.Stop();
        Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
    }
}
