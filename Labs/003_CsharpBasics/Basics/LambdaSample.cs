using System;

namespace Basics
{
    public class LambdaSample : ISample
    {
        public void Run()
        {
            //Statement lambdas
            //Action<string> greet = async (name)  =>
            //{
            //    string greeting = $"Hello {name}!";
            //    Console.WriteLine(greeting);
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    Console.WriteLine();
            //};

            //Action<string> greet2 = (_)  =>
            //{
            //    Console.WriteLine("Hello from lambda");
            //};

            //greet?.Invoke("asdsa");

            //greet("World");


            Test23(jozo => Console.WriteLine("bu"));

            //Expression lambdas
            Action line = () => Console.WriteLine("Ahoooj");
            Func<string> test = () => "ahooooooj";

            CreateErrorMessage<User>(user => user.Name);
            CreateErrorMessage<TestUser>(user => user.FullName);
            CreateErrorMessage<User>(_ => "Debug test user");

            Func<int, int, bool> testForEquality = (x, y) => x == y;
            Func<int, int, int> constant = (_, _) => 42;
        }

        class User
        {
            public string Name { get; set; } = "User Jozo";
        }
        class TestUser
        {
            public string FullName { get; set; } = "Test User Fero";
        }

        void Test(string name)
        {

        }

        void Test23(Action<string> action)
        {
            Console.WriteLine("HA");
            action("asdasdasdas");
        }


        void CreateErrorMessage<T>(Func<T, string> getUserName) where T : new()
        {
            var user = new T();

            var userName = getUserName(user);
            Console.WriteLine(userName);
        }

    }
}