using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Basics
{
    public class LINQSample : ISample
    {
        public void Run()
        {
            Sample0();
            Sample1();
            Sample3();
        }

        private void Sample0()
        {
            var strings = new[] {"Tom", "Dick", "Mary", "Harry", "Jay"};
            var queryFluentSyntax = strings
                .Where(name => name.Contains("a"))
                .OrderBy(nameAfterWhere => nameAfterWhere.Length)
                .Select(orderedName => new {Name = orderedName.ToUpper()});

            var test2 = new {haha = "asdas"};

            var test = new {Name = "MySuperName", Age = 44};
            var items = queryFluentSyntax.ToList();
            var itemsBetter = items.Select((value, i) => new {i, value});

            foreach (var item in items) Console.WriteLine(item);

            var queryQuerySyntax =
                from name in strings
                where name.Contains("a")
                orderby name.Length
                select name.ToUpper();
        }

        public void Sample1()
        {
            var numbers = new int[7] {0, 1, 2, 3, 4, 5, 6};

            var numQuery =
                from num in numbers
                where num % 2 == 0
                orderby num
                select num;

            foreach (var num in numQuery) Console.Write("{0,1} ", num);
        }

        public void Sample2()
        {
            var musos = new[] {"David Gilmour", "Roger Waters", "Rick Wright", "Nick Mason"};

            IEnumerable<string> queryFluent = musos.OrderBy(m => m.Split().Last());

            var query = from m in musos
                orderby m.Split().Last()
                select m;
        }


        public void Sample3()
        {
            var students = new List<Student>
            {
                new()
                {
                    FirstName = "Svetlana",
                    LastName = "Omelchenko",
                    ID = 111,
                    Street = "123 Main Street",
                    City = "Seattle",
                    Scores = new List<int> {97, 92, 81, 60}
                },
                new()
                {
                    FirstName = "Claire",
                    LastName = "O’Donnell",
                    ID = 112,
                    Street = "124 Main Street",
                    City = "Redmond",
                    Scores = new List<int> {75, 84, 91, 39}
                },
                new()
                {
                    FirstName = "Sven",
                    LastName = "Mortensen",
                    ID = 113,
                    Street = "125 Main Street",
                    City = "Lake City",
                    Scores = new List<int> {88, 94, 65, 91}
                }
            };

            // Create the second data source.
            var teachers = new List<Teacher>
            {
                new() {First = "Ann", Last = "Beebe", ID = 945, City = "Seattle"},
                new() {First = "Alex", Last = "Robinson", ID = 956, City = "Redmond"},
                new() {First = "Michiyo", Last = "Sato", ID = 972, City = "Tacoma"}
            };

            var ofTypeWhere = students.Where(s => s.GetType() == typeof(string));
            var ofTypeWhere2 = students.Where(s => s is string);
            var ofType = students.OfType<string>();

            var select = students.Select(i => i.FirstName).Select(i => i.Length);
            var sum = select.Max();

            var sum2 = students.Max(s => s.FirstName.Length);
            var sum3 = students.Max(s => s?.FirstName.Length ?? 0);

            if (students.Count > 0)
            {
                //code
            }

            if (students.Any(s => s.FirstName == "Karol"))
            {
                //code
            }

            Func<Student, bool> myPrediction = s => s.FirstName == "Karol";
            if (students.Any(myPrediction))
            {
                //code
            }

            if (students.All(myPrediction))
            {
            }

            var secondPage = students.Skip(10).Take(10);

            var take = students.SkipWhile(s => s.FirstName == "Fero").Take(10);

            var empty = Enumerable.Empty<Student>();

            var range = Enumerable.Range(0, 20).Select(_ => new {Age = 15, Name = "Jzoo"});

            var enumerable = students
                .Where(s => s.City == "Seattle")
                .Select(s => new {HAHA = s.FirstName, HEHE = s.LastName, Test = "selectbycity"})
                .Where(s => s.Test == "Seattle")
                .Select(i => i.Test)
                .Where(s => s.Contains("ha"));

            var itemsTest = enumerable.ToList();
            var item = itemsTest[0];


            // Create the query.
            var peopleInSeattle = (from student in students
                    where student.City == "Seattle"
                    select student.LastName)
                .Concat(from teacher in teachers
                    where teacher.City == "Seattle"
                    select teacher.Last);

            Console.WriteLine("The following students and teachers live in Seattle:");
            // Execute the query.
            foreach (var person in peopleInSeattle) Console.WriteLine(person);
        }


        private class Student
        {
            public List<int> Scores { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
            public string Street { get; set; }
            public string City { get; set; }

            public int? Age { get; set; }
        }

        private class Teacher
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public string City { get; set; }
        }
    }

    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public static class Extensions
    {
        public static IEnumerable<T> MySkipWhile<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            return enumerable;
        }

        public static void Test()
        {
            var enumerable = Enumerable.Empty<int>();

            // ReSharper disable once InvokeAsExtensionMethod
            MySkipWhile(enumerable, i => i > 5);

            enumerable.MySkipWhile(i => i > 5);
        }
    }
}