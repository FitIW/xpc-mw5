using School.DAL;
using School.DAL.Entities;
using School.DAL.QueryObjects;
using School.DAL.QueryObjects.Filters;
using School.DAL.Repositories;

namespace School.App;

class Program
{
    public static void Main(string[] args)
    {
        var studentRepository = new StudentRepository();
        
        // Create students
        var id1 = studentRepository.Create(new StudentEntity()
        {
            Name = "Samuel Janek",
            Program = "NSEN",
            Address = new AddressEntity()
            {
                City = "Brno",
                State = "CR"
            }
        });
        var id2 = studentRepository.Create(new StudentEntity()
        {
            Name = "Peter Noha",
            Program = "NSEN",
            Address = new AddressEntity()
            {
                City = "Praha",
                State = "CR"
            }
        });
        var id3 = studentRepository.Create(new StudentEntity()
        {
            Name = "Dominik Noha",
            Program = "NSEN",
            Address = new AddressEntity()
            {
                City = "Brno",
                State = "CR"
            }
        });
        
        Database.Instance.ShowData();
        
        // Get student by Id
        Console.WriteLine("\nOPERATION: studentRepository.GetById(id1)");
        var student1 = studentRepository.GetById(id1);
        Console.WriteLine(student1);
        
        // Update student
        Console.WriteLine("\nOPERATION: studentRepository.Update(student1 with { Name = 'JANO SAMEK' })");
        studentRepository.Update(student1 with { Name = "JANO SAMEK" });
        Console.WriteLine(studentRepository.GetById(id1));
        
        // Get students using StudentDataFilter { Name: 'Noha', Program: 'NSEN' }
        Console.WriteLine("\nOPERATION: Get students using StudentDataFilter { Name: 'Noha', Program: 'NSEN' }");
        var results = new GetStudentsByStudentDataFilterQuery().Execute(new StudentDataFilter("Noha", "NSEN"));
        foreach (var r in results)
        {
            Console.WriteLine(r);
        }

        // Delete student by id
        Console.WriteLine("\nOPERATION: studentRepository.Delete(id2)");
        studentRepository.Delete(id2);
        
        Database.Instance.ShowData();
    }
}