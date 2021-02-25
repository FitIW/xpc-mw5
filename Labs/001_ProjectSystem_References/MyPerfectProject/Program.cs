using System;
using ClassLibrary1;
using MyPerfectProject.Folder;

namespace MyPerfectProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var i = 5;
            {
                var ii = 44;
                i = 8;
            }

            //var @class = "adssa";
            var test = new Test();
            var class1 = new Class1();
            var myProgramClass2 = new MyProgramClass2();
            //var myClass = new Class1.MyClass();

            // not allowed call non static member from static context
            // MyMethod(5);
        }

        public void MyMethod(int age)
        {
            //calling static member in scope
            Main(new[] {"asd"});
        }
    }

    internal class MyProgramClass2
    {
        public MyProgramClass2()
        {
            //calling static member of class program
            var arguments = new[] {"asd"};
            Program.Main(arguments);
        }
    }
}