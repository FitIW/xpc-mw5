namespace Stack;

public record Item<T>(T Value)
{
    // public T Value { get; init; }
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime DateTimeCreated { get; } = DateTime.UtcNow;
}