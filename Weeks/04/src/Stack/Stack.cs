using System.Collections;
using System.Text;
using Stack.Exceptions;

namespace Stack;

public sealed class Stack<T> : IEnumerable<Item<T>>
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

    // Wee need to implement this method because we implement IEnumerable<T> interface
    public IEnumerator<Item<T>> GetEnumerator()
    {
        return new Enumerator(this._items);
    }
    
    // Wee need to implement this method because we implement IEnumerable interface
    IEnumerator IEnumerable.GetEnumerator()
    {
        return new Enumerator(this._items);
    }

    // Custom enumerator class
    public class Enumerator : IEnumerator<Item<T>>
    {
        private readonly Item<T>[] _items;
        private int _index;
        private Item<T>? _current;
        
        public Enumerator(Item<T>[] items)
        {
            _items = items;
            _index = 0;
            _current = default;
        }
        
        public bool MoveNext()
        {
            if (_index < _items.Length)
            {
                _current = _items[_index];
                _index++;
                return true;
            }

            _current = default;
            return false;
        }

        public void Reset()
        {
            _index = 0;
            _current = default;
        }

        public Item<T> Current => _current!;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
    
    // Iterator method
    public IEnumerable<Item<T>> GetItems()
    {
        foreach (var item in _items)
        {
            yield return item;
        }
    }
}