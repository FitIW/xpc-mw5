namespace SpecFlowExamples.Models
{
    public class Magazine
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; set; }
    }
}
