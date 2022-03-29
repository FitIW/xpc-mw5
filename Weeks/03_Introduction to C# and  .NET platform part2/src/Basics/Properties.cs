using System;

namespace Basics
{
    // ReSharper disable ArrangeAccessorOwnerBody
    // ReSharper disable ConvertToAutoProperty
    public class Properties : ISample
    {
        public Properties(string nameWithBackingField)
        {
            MySuperNameWithBackingField = nameWithBackingField;
            NameWithDefaultInitValue = "test";
        }

        public string MySuperNameWithBackingField { get; set; }

        public string NameWithBackingField2 { get; protected set; }

        public string NameGetOnly
        {
            get { return NameWithBackingField2; }
        }

        //Get only property
        public string NameGetOnlyArrow
        {
            get
            {
                return $"{NameWithBackingField2} + {(MySuperNameWithBackingField.Contains("test") ? "test" : "nope")}";
            }
        }


        public string Name { get; set; }

        public string NameWithDefaultValue { get; set; } = "Albert";
        public string NameWithDefaultInitValue { get; init; } = "Albert";

        public void Run()
        {
            Console.WriteLine(MySuperNameWithBackingField);
            Console.WriteLine(NameWithBackingField2);

            NameWithBackingField2 = "dasdas";
            var tes = NameWithBackingField2;

            var properties = new Properties("")
            {
                NameWithDefaultInitValue = "Karol"
            };
        }

        public void TryUpdateValueInNameWithDefaultInitValue()
        {
            //this.NameWithDefaultInitValue = "aaa";
        }
    }
}