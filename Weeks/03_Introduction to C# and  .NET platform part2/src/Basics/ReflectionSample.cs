using System;
using System.IO;
using System.Reflection;

namespace Basics
{
    public class ReflectionSample : ISample
    {
        public void Run()
        {
            // Using GetType to obtain type information:
            var i = 42;
            var type = i.GetType();
            Console.WriteLine(type);

            var dateTime = (DateTime)Activator.CreateInstance(typeof(DateTime));

            var assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dllPath = Path.Combine(assemblyFolder, "ReflectionSupportProject.dll");

            var testAssembly = Assembly.LoadFile(dllPath);
            // get type of class Calculator from just loaded assembly
            var calcType = testAssembly.GetType("ReflectionSupportProject.Calculator");

            // create instance of class Calculator
            var calcInstance = Activator.CreateInstance(calcType);

            var numberPropertyInfo = calcType.GetProperty("Number");

            // get value of property: public double Number
            var value = (double)numberPropertyInfo.GetValue(calcInstance, null);

            // set value of property: public double Number
            numberPropertyInfo.SetValue(calcInstance, 10.0, null);
        }
    }
}