namespace School.DAL.Entities;

public record CourseEntity : EntityBase
{
    public required string Name { get; set; }
    public required uint Capacity { get; set; }

    // Course can have many students
    public ICollection<StudentEntity>? Students { get; set; }
    
    // Course can have multiple exams
    public ICollection<ExamEntity>? Exams { get; set; }
}