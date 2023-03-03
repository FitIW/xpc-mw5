using Cooking.Food;

namespace Cooking;

public class AsyncFastVersion
{
    public static async Task RunAsync()
    {
        Coffee cup = PourCoffee();
        Console.WriteLine("Caffe ready");
        
        Task<Egg> eggs = FryEggs();
        Task<Bacon> bacon = FryBacon();
        
        Toast toast = await ToastBread();
        ApplyButter(toast);
        ApplyJam(toast);
        Console.WriteLine("Toast ready");

        await eggs;
        Console.WriteLine("Eggs ready");
        
        await bacon;
        Console.WriteLine("Bacon ready");
    }

    private static void ApplyJam(Toast toast) => Console.WriteLine("Putting jam on the toast");
    private static void ApplyButter(Toast toast) => Console.WriteLine("Putting butter on the toast");

    private static async Task<Toast> ToastBread()
    {
        await Task.Delay(2000);
        return new Toast();
    }

    private static async Task<Bacon> FryBacon()
    {
        await Task.Delay(5000);
        return new Bacon();
    }

    private static async Task<Egg> FryEggs()
    {
        await Task.Delay(5000);
        return new Egg();
    }

    private static Coffee PourCoffee()
    {
        return new Coffee();
    }
}