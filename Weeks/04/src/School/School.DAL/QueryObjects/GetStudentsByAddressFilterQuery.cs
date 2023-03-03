using School.DAL.Entities;
using School.DAL.QueryObjects.Filters;

namespace School.DAL.QueryObjects;

public class GetStudentsByAddressFilterQuery : IQuery<StudentEntity, AddressFilter>
{
    public IEnumerable<StudentEntity> Execute(AddressFilter filter)
    {
        return Database.Instance.Students.Where(s => s.Address.City == filter.City && s.Address.State == filter.State);
    }
}