using Cooking.Food;

namespace Cooking;

public class SyncVersion
{
    public static void Run()
    {
        Coffee cup = PourCoffee();
        Console.WriteLine("Caffe ready");
        
        Egg eggs = FryEggs();
        Console.WriteLine("Eggs ready");

        Bacon bacon = FryBacon();
        Console.WriteLine("Bacon ready");

        Toast toast = ToastBread();
        ApplyButter(toast);
        ApplyJam(toast);
        Console.WriteLine("Toast ready");
    }

    private static void ApplyJam(Toast toast) => Console.WriteLine("Putting jam on the toast");
    private static void ApplyButter(Toast toast) => Console.WriteLine("Putting butter on the toast");

    private static Toast ToastBread()
    {
        Task.Delay(2000).Wait();
        return new Toast();
    }

    private static Bacon FryBacon()
    {
        Task.Delay(5000).Wait();
        return new Bacon();
    }

    private static Egg FryEggs()
    {
        Task.Delay(5000).Wait();
        return new Egg();
    }

    private static Coffee PourCoffee()
    {
        return new Coffee();
    }
}