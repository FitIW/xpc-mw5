using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public class DelegateSample
    {
        public interface IPerson
        {
            int Age { get;  }
        }

        private class Person : IPerson
        {
            public int Age { get; }
        }

        public delegate int GetAge(IPerson person);

        public void Run()
        {
            //GetAge getAgeDelegate = GetAbrakaDabra;
            //Test(GetAbrakaDabra);
            //TestFunc(GetAbrakaDabra2);

            Action<int, string> mySuperAction = MySuperAction;

            mySuperAction += (age, name) =>
            {

            };

            // this replace previous methods
            //mySuperAction = (a, b) => { };


            Action<int, string> mySuperAction2 = (age, name) =>
            {

            };
            //usage of discards
            Action<int, string> mySuperAction3 = (_, _) =>
            {

            };


            Func<IPerson, string, int> ageFunc = (person, name) =>
            {
                var personAge = person.Age + 100;
                var newName = $"{name} haha";
                Console.WriteLine(newName);
                return 0;
            };

            TestFunc(ageFunc );
        }

        private void MySuperAction(int arg1, string arg2)
        {
            throw new NotImplementedException();
        }

        public void Test(GetAge getAgeDelegate)
        {
            var person = new Person();
            var ageDelegate = getAgeDelegate(person);
            Console.WriteLine(ageDelegate);
        }

        public void TestFunc(Func<IPerson,string,int> getAgeFunc)
        {
            var person = new Person();

            //if (getAgeFunc != null)
            //{
            //    getAgeFunc(person, "ahoj");
            //}

            getAgeFunc?.Invoke(person, "ahoj");

            var ageDelegate = getAgeFunc(person, "ahoj");
            Console.WriteLine(ageDelegate);
        }


        public int GetAbrakaDabra(IPerson person)
        {
            return person.Age + 5;
        }
        public int GetAbrakaDabra2(IPerson person, string test)
        {
            return person.Age + 5;
        }
    }
}
