using System.Text;

namespace Delegates;

public static class ArrayExtensions
{
    public static void Transform(this string[] array, Func<string, string> transformer)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = transformer(array[i]);
        }
    }

    public static void Print(this string[] array)
    {
        var builder = new StringBuilder();
        builder.Append("{ ");
        foreach (var item in array)
        {
            builder.Append($"{item}, ");
        }
        builder.Append(" }");
        Console.WriteLine(builder.ToString());
    }
}