using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public class LocalFunctionSample : ISample
    {
        public void Run()
        {

            Console.WriteLine(getAge("asdasdas"));
            int age = getElement<int>("age");


            T getElement<T>(string xmlElement)
            {
                object value = ""; // getElementValue
                return (T)value;
            }

            int getAge(string name) => 5;
            Func<string, int> getAgeFunc = (name) => 5;
        }
    }
}
