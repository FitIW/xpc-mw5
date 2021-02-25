using System;
using System.Collections.Generic;
using System.Linq;

namespace Basics
{
    public class Generics : ISample
    {
        public void Run()
        {
            var myFirstGenericClass = new MyFirstGenericClass<int, IPerson>();
            myFirstGenericClass.SomeType = 44; // int
            var student = new Student();
            var teacher = new Teacher();
            myFirstGenericClass.SomeMethod(7777, teacher, person => person.Name);


            var a = myFirstGenericClass.SomeType;
            var test = (string) null;

            var myFirstGenericMethod = MyFirstGenericMethod(new SimpleEntity());

            //covariance
            IEnumerable<IPerson> covarianceSample = new List<ITeacher>();

            //contravariance
            Func<IPerson> contravarianceSample = () => new object() as ITeacher;


            var userRepository = new UserRepository();
            UserEntity userEntity = userRepository.GetById(Guid.NewGuid());
            var test2Repository = new Test2Repository();
            TestEntity testEntity = test2Repository.GetById(Guid.NewGuid());
        }

        public T MyFirstGenericMethod<T>(T item) where T : IEntity
        {
            return item;
        }

        public interface IPerson
        {
            string Name { get; }
        }

        public interface IStudent : IPerson
        {
        }

        private class Student : IStudent
        {
            public string SurName { get; }
            public string Name { get; }
        }

        public interface ITeacher : IPerson
        {
        }

        public class Teacher : ITeacher
        {
            public string Name { get; set; }
        }

        public class MyFirstGenericClass<T, TPerson> where TPerson : IPerson //, new()
        {
            public MyFirstGenericClass()
            {
                var myService = new MyService<MyapplicationSettings>();


                myService.SetupService(settings => new Uri(settings.Url), s => s.Name);

                myService.SendMessage("ahoooooj");

                var myService2 = new MyService<ComplicatedSettings>();

                myService2.SetupService(settings => new Uri(settings.BaseSettings.Url), s => s.BaseSettings.Name);
                myService.SendMessage("ahoooooj");
            }

            public T SomeType { get; set; }

            public void SomeMethod<TSpecificPerson>(T arg, TSpecificPerson person,
                Func<TSpecificPerson, string> getNameFunc)
                where TSpecificPerson : TPerson
            {
                //var personLocal = new TPerson();
                var personName = getNameFunc(person);
                //arg2.Name

                Console.WriteLine(arg.GetType().ToString());
            }
        }


        public interface IEntity
        {
            Guid Id { get; }
        }

        private class SimpleEntity : IEntity
        {
            public Guid Id { get; }
        }


        public interface IEntity<TId>
        {
            TId Id { get; }
        }

        public abstract class EntityBase<TId> : IEntity<TId>
        {
            public TId Id { get; protected set; }
        }

        public class UserEntity : EntityBase<Guid>
        {
            public UserEntity(Guid id)
            {
                Id = id;
            }

            public bool IsDeleted { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class UserDto
        {
            public UserDto(Guid id)
            {
                Id = id;
            }

            public bool IsDeleted { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public Guid Id { get; set; }
        }

        public class TestEntity : EntityBase<Guid>
        {
            public TestEntity(Guid id)
            {
                Id = id;
            }
        }


        public class ItemEntity : EntityBase<int>
        {
            public ItemEntity(int id)
            {
                Id = id;
            }
        }


        public abstract class RepositoryBase<TEntity, TId>
            where TEntity : IEntity<TId>
            where TId : struct
        {
            //dbContext.Set<TEntity>
            protected readonly IEnumerable<TEntity> Entitites;

            protected RepositoryBase()
            {
                //ioc inject
                Entitites = new List<TEntity>();
            }


            public virtual TEntity GetById(TId id)
            {
                return Entitites.First(e => e.Id.Equals(id));
            }
        }

        public class UserRepository : RepositoryBase<UserEntity, Guid>
        {
        }

        public class Test2Repository : RepositoryBase<TestEntity, Guid>
        {
        }

        public class AdminUserRepository : RepositoryBase<UserEntity, Guid>
        {
            public override UserEntity GetById(Guid id)
            {
                return Entitites.First(e => e.Id == id);
            }
        }

        public abstract class QueryBase<TEntity, TId, TFilter>
            where TEntity : IEntity<TId>
        {
            public abstract ICollection<TEntity> Execute(TFilter filter);
        }

        public class UserFilter
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        private class UserQuery : QueryBase<UserEntity, Guid, UserFilter>
        {
            public override ICollection<UserEntity> Execute(UserFilter filter)
            {
                //injected / dbcontext...
                IEnumerable<UserEntity> myDataSet = new List<UserEntity>();


                return myDataSet.Where(e => e.Name == filter.Name && e.Age == filter.Age).ToList();
            }
        }

        public abstract class FacadeBase<TEntity, TId, TFilter, TDto> where TEntity : IEntity<TId> where TId : struct
        {
            private readonly QueryBase<TEntity, TId, TFilter> query;
            private readonly RepositoryBase<TEntity, TId> repository;

            protected FacadeBase(RepositoryBase<TEntity, TId> repository, QueryBase<TEntity, TId, TFilter> query)
            {
                this.repository = repository;
                this.query = query;
            }
        }

        public class UserFacade : FacadeBase<UserEntity, Guid, UserFilter, UserDto>
        {
            public UserFacade(
                RepositoryBase<UserEntity, Guid> repository, 
                QueryBase<UserEntity, Guid, UserFilter> query) 
                : base(repository, query)
            {
            }
        }

        public class MyapplicationSettings
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }

        public class ComplicatedSettings
        {
            public MyapplicationSettings BaseSettings { get; set; }

            public string Test { get; set; }
        }

        private class MyService<TSettings>
        {
            private readonly TSettings settings;
            private Func<TSettings, Uri> getServiceUrlFunc;

            public void SetupService(Func<TSettings, Uri> getServiceUrlFunc, Func<TSettings, string> getServiceName)
            {
                this.getServiceUrlFunc = getServiceUrlFunc;
                Console.WriteLine($"service with name {getServiceName(settings)}is setup");
            }

            public void SendMessage(string message)
            {
                Console.WriteLine($"send message:  '{message}', to url {getServiceUrlFunc(settings)}");
            }
        }

        public class TestRepository : RepositoryBase<TestEntity, Guid>
        {
            public TestRepository()
            {
                var userRepository = new UserRepository();
                var userQuery = new UserQuery();

                var userFacade = new UserFacade(userRepository, userQuery);

                var adminUserRepository = new AdminUserRepository();
                var adminUserFacade = new UserFacade(adminUserRepository, userQuery);
            }
        }
    }
}