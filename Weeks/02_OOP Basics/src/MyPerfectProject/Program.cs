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
        }

        public void MyMethod(int age)
        {
            Main(new[] {"asd"});
        }
    }

    internal class MyProgramClass2
    {
        public MyProgramClass2()
        {
            Program.Main(new[] {"asd"});
        }
    }
}