using System;

namespace Basics
{
    public class MethodParameters : ISample
    {
        public void Run()
        {
            //params
            Console.WriteLine("Params");
            UseParams(1, 2, 3, 4);

            // in parameter
            var readonlyArgument = 44;
            InArgExample(readonlyArgument);
            Console.WriteLine(readonlyArgument); // value is still 44

            // in parameters
            var number = 1;
            RefArgExample(ref number);
            Console.WriteLine(number); // value is 45

            //out parameters
            Console.WriteLine("out parameter");
            int initializeInMethod;
            OutArgExample(out initializeInMethod);
            Console.WriteLine(initializeInMethod); // value is now 44

            object test = "asdas";
            //int resultNumber;
            //bool isNumber = TryConvert(test, out resultNumber);

            if (TryConvert(test, out var resultNumber)) Console.WriteLine(resultNumber);

            // named parameters
            NamedParameters(sex: "male", name: "Jožo", age: 25);
        }

        private void NamedParameters(int age, string name, string sex)
        {
            Console.WriteLine($"{name}, {age}, {nameof(sex)}:{sex}");
        }

        private void InArgExample(in int number)
        {
            // Uncomment the following line to see error CS8331
            //number = 19;
        }

        private void RefArgExample(ref int refArgument)
        {
            refArgument = refArgument + 44;
        }

        private bool TryConvert(object obj, out int number)
        {
            if (obj is int)
            {
                number = obj is int ? (int)obj : 0;
                return true;
            }

            number = 0;
            return false;
        }

        private void OutArgExample(out int number)
        {
            number = 44;
        }

        private void UseParams(params int[] list)
        {
            foreach (var item in list) Console.Write(item + " ");
            Console.WriteLine();
        }
    }
}