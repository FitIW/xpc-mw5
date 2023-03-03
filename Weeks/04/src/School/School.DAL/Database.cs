using School.DAL.Entities;

namespace School.DAL;

public class Database
{
    private static readonly Lazy<Database> LazyDatabase =
        new Lazy<Database>(() => new Database());
    
    public static Database Instance => LazyDatabase.Value;

    private Database()
    {
    }
    
    public ICollection<AddressEntity> Addresses { get; } = new List<AddressEntity>();
    public ICollection<CourseEntity> Courses { get; } = new List<CourseEntity>();
    public ICollection<ExamEntity> Exams { get; } = new List<ExamEntity>();
    public ICollection<StudentEntity> Students { get; } = new List<StudentEntity>();

    public void ShowData()
    {
        Console.WriteLine("--------------------------");
        
        Console.WriteLine("# Addresses:");
        foreach (var a in Addresses)
        {
            Console.WriteLine(a);
        }
        
        Console.WriteLine("# Courses:");
        foreach (var c in Courses)
        {
            Console.WriteLine(c);
        }
        
        Console.WriteLine("# Exams:");
        foreach (var e in Exams)
        {
            Console.WriteLine(e);
        }
        
        Console.WriteLine("# Students:");
        foreach (var s in Students)
        {
            Console.WriteLine(s);
        }
        
        Console.WriteLine("--------------------------");
    }
}