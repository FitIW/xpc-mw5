namespace School.DAL.Entities;

public record ExamEntity : EntityBase
{
    public required DateTime DateTime { get; set; }
    public required uint Capacity { get; set; }
    public required string Room { get; set; }
    
    // Multiple students can attend one exam
    public ICollection<StudentEntity>? Students { get; set; }
}