﻿using System;

namespace ClassLibrary1
{
    public class Class1
    {
        public Class1()
        {
            MyClass myClass = new MyClass();
            
            Nullable<int> bb = null;
            int? bbb = null;

            int bbbb = 77;

        }

        /// <summary>
        /// Class description...
        /// </summary>
        internal class MyClass
        {
            /// <summary>
            /// Method description...
            /// </summary>
            public MyClass()
            {
            }
        }
    }

    public class Class2
    {
       
        public Class2()
        {
            var a = new Class1.MyClass();
        }
    }
}
