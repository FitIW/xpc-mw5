using System.Text;
using Stack.Exceptions;

namespace Stack;

public sealed class Stack<T>
{
    private readonly Item<T>[] _items;
    private int _top = -1;
    
    public uint Capacity { get; }

    public Stack(uint capacity)
    {
        _items = new Item<T>[capacity];
        Capacity = capacity;
    }
    
    public void Push(T value)
    {
        if (_top == Capacity - 1)
        {
            throw new StackIsFullException();
        }

        _top++;
        _items[_top] = new Item<T>(value);
    }

    public T Pop()
    {
        if (_top == -1)
        {
            throw new StackIsEmptyException();
        }

        var item = _items[_top];
        _top--;
        return item.Value;
    }

    public T? Peek() => _top != -1 ? (_items[_top]).Value : throw new StackIsEmptyException();

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine("Stack:");
        builder.AppendLine("{");
        foreach (var item in _items)
        {
            builder.AppendLine(item.ToString());
        }
        builder.AppendLine("}");
        return builder.ToString();
    }

    public Item<T> this[uint index]
    {
        get
        {
            if (index <= _top)
            {
                return _items[index];
            }
            throw new StackIsEmptyException();
        }
    }
}