namespace School.DAL.Entities;

public record StudentEntity : EntityBase
{
    public required string Name { get; set; }
    public required string Program { get; set; }
    
    // Student has one address
    public required AddressEntity Address { get; set; }
    
    // Student can have many courses
    public ICollection<CourseEntity>? Courses { get; set; }

    // Student can have many exams
    public ICollection<ExamEntity>? Exams { get; set; }
}