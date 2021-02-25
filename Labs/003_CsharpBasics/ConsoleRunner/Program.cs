using System;
using System.Collections.Generic;
using Basics;

namespace ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
          

            
            new DelegateSample().Run();
            new Exceptions().Run();
            new EnumerableSample().Run();
            new Operators().Run();


            new Attributes().Run();
            new Attributes().Run();
            new Attributes().Run();
            Console.WriteLine("Hello World!");
        }

    }
}
