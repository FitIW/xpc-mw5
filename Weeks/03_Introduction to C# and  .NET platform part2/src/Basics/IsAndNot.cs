using System;

namespace Basics
{
    public class IsAndNot : ISample
    {
        public void Run()
        {
            object e = null;
            if (e is Customer customer)
            {
                Console.WriteLine($"Type is {nameof(Customer)} with name {customer.Name}");
            }

            if (e is not Customer)
            {
                Console.WriteLine($"Type is not type {nameof(Customer)}");
            }
        }

        public class Customer
        {
            public string Name { get; set; }
        }
    }
}