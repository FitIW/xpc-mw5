using System;

namespace Basics
{
    public class CtorFinalizer : ISample
    {
        public void Run()
        {
            var myClass = new MyClass();
            var myClass2 = new MyClass(55);
        }

        public abstract class MySuperBase : MySuperBaseBase
        {
            protected MySuperBase(int aa) : base(aa)
            {
                Console.WriteLine("MySuperBase " + aa);
            }
        }

        public abstract class MySuperBaseBase
        {
            protected MySuperBaseBase(int aa)
            {
                Console.WriteLine("MySuperBaseBase " + aa);
            }
        }
        public class MyClass : MySuperBase
        {
            public MyClass() : base(88)
            {
                Console.WriteLine("MyClass");
            }
            public MyClass(int arg1) : base(66)
            {
                Console.WriteLine("MyClass");
            }
        }
    }
}