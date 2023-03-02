namespace Delegates;

class Program
{
    static void Main(string[] args)
    {
        // Func example
        string[] arr = new[] { "Harry", "Gary", "Mike", "Adam" };
        
        Func<string, string> toUpperCase = (string value) =>
        {
            return value.ToUpper();
        };
        Func<string, string> toLowerCase = (string value) => value.ToLower();
        Func<string, string> clone = (string value) => value + value;

        arr.Transform(toUpperCase);
        arr.Print();
        
        arr.Transform(toLowerCase);
        arr.Print();
        
        arr.Transform(clone);
        arr.Print();

        // Action example
        Action<string> actions = null;
        actions += (s) => Console.WriteLine("1 " + s);
        actions += (s) => Console.WriteLine("2 " + s);
        actions += (s) => Console.WriteLine("3 " + s);
        actions("action");

        var numbers = Enumerable.Range(0, 5);
        foreach (var number in numbers)
        {
            ShowNumberInfo(number);
        }
    }

    static void ShowNumberInfo(int number)
    {
        var isEven = number % 2 == 0;
        Console.WriteLine($"Number is {(isEven ? "EVEN" : "ODD")}");
    }
}
