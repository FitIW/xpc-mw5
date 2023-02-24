using Stack.Exceptions;

namespace Stack;

class Program
{
    static void Main(string[] args)
    {
        var stack = new Stack<int>(3);

        try
        {
            stack.Pop();
        }
        catch (StackIsEmptyException e)
        {
            Console.WriteLine("StackIsEmptyException");
        }
        
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.WriteLine($"Capacity of a stack is {stack.Capacity}");
        Console.WriteLine(stack);

        try
        {
            stack.Push(4);
        }
        catch (StackIsFullException e)
        {
            Console.WriteLine("StackIsFullException");
        }

        Console.WriteLine(stack[1]);
    }
}
