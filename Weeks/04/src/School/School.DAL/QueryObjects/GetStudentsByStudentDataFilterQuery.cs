using School.DAL.Entities;
using School.DAL.QueryObjects.Filters;

namespace School.DAL.QueryObjects;

public class GetStudentsByStudentDataFilterQuery : IQuery<StudentEntity, StudentDataFilter>
{
    public IEnumerable<StudentEntity> Execute(StudentDataFilter filter)
    {
        return Database.Instance.Students
            .Where(s => s.Name.Contains(filter.Name) && s.Program == filter.Program);
    }
}