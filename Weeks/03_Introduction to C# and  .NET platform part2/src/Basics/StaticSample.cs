
using System;
using Basics;

namespace System
{
    public static class StringUtils
    {
        public static MyString UpdateMyString(this MyString myString)
        {
            myString.Value = $"**{myString}**";
            return myString;
        }

        public static bool IsNullOrEmpty(this string myString)
        {
            return string.IsNullOrEmpty(myString);
        }
    }

}

namespace Basics
{
    public class MyString
    {
        public string Value { get; set; }
    }

    public static class StaticSample
    {
        
        public static void Test()
        {
            var test2 = new Test2();

            //not allowed
            //test2.StaticMethod();
            Test2.StaticMethod();


            var mySecretValue = new MyString {Value = "asdsadas"};
            var updateMyString = StringUtils.UpdateMyString(mySecretValue);

            var updateMyString2 = mySecretValue.UpdateMyString();

            string test = "";

            //string.IsNullOrEmpty(myString)
            if (test.IsNullOrEmpty())
            {

            }

        }
    }



  

    public class Test2
    {
        public static void StaticMethod()
        {
        }

        public void MyNonStaticMethod()
        {
            StaticMethod();
        }
    }
}