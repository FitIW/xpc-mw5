namespace CancellationTokens;

class Program
{
    static async Task Main(string[] args)
    {
        var cts = new CancellationTokenSource();
        
        Console.CancelKeyPress += (s, e) =>
        {
            Console.WriteLine("Canceling...");
            cts.Cancel();
            e.Cancel = true;
        };
    
        Console.WriteLine("I am going to do some async work");
        try
        {
            // This method called is wrapped in try block because cancellation causes TaskCanceledException
            await DoSomethingAsync(cts.Token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        Console.WriteLine("I am done...");
    }

    static async Task DoSomethingAsync(CancellationToken token)
    {
        Console.WriteLine("This will take 5 seconds");
        await Task.Delay(5000, token);
        Console.WriteLine("The task is finished");
    }
    
    // static async Task Main(string[] args)
    // {
    //     var cts = new CancellationTokenSource();
    //     
    //     Console.CancelKeyPress += (s, e) =>
    //     {
    //         Console.WriteLine("Canceling...");
    //         cts.Cancel();
    //         e.Cancel = true;
    //     };
    //
    //     Console.WriteLine("I am going to do some async work");
    //     
    //     await RunAsync(cts.Token);
    //     
    //     Console.WriteLine("I am done...");
    // }
    //
    // static async Task RunAsync(CancellationToken token)
    // {
    //     var counter = 0;
    //     while (!token.IsCancellationRequested)
    //     {
    //         Console.WriteLine(counter);
    //         counter++;
    //         await Task.Delay(1000);
    //     }
    // }
}
