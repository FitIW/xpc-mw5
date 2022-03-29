namespace SpecFlowExamples.Models
{
    public class Book
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
    }
}
