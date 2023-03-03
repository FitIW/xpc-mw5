using School.DAL.Entities;

namespace School.DAL.Repositories;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    Guid Create(TEntity? entity);
    TEntity GetById(Guid id);
    TEntity Update(TEntity? entity);
    void Delete(Guid id);
}
