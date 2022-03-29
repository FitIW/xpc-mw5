using System;
using System.Collections;
using System.Collections.Generic;

namespace Basics
{
    public class EnumerableSample : ISample
    {
        public void Run()
        {
            //var myType = new MyType();

            //foreach (var o in myType) Console.WriteLine(o);

            //var strings = new string[] { "das", "asdsa" };
            ////var strings = new List<string>() {"das", "asdsa" };

            //var enumerator = strings.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    var enumeratorCurrent = enumerator.Current;
            //}
            //enumerator.Reset();

            //foreach (string s in strings)
            //{
            //    Console.WriteLine(s);
            //}


            var maxCount = 2;
            var count = 0;
            foreach (var i in GetNumbers())
            {
                if (i < 2)
                {
                    count++;
                }

                Console.WriteLine(i);
                if (maxCount == count)
                {
                    break;
                }
            }

            foreach (var item in new TestEnumerableDuckTyping()) Console.WriteLine(item);

            var testEnumerable = new TestEnumerable();
            var enumerator = testEnumerable.GetEnumerator().MoveNext();

            IEnumerable testEnumerable2 = testEnumerable;
            var enumerator1 = testEnumerable2.GetEnumerator().MoveNext();

            foreach (var item in new TestEnumerable()) Console.WriteLine(item);

            foreach (var number in GetNumbers(15)) Console.WriteLine(number);
        }

        public IEnumerable<int> SimpleEnumerable()
        {
            Console.WriteLine("first");
            yield return 1;
            Console.WriteLine("second");
            yield return 2;
            Console.WriteLine("third");
            yield return 5;
            Console.WriteLine("4th");
            //yield break;
            yield return 1;
            Console.WriteLine("5th");
            yield return 8;
            Console.WriteLine("6th");
            yield return 0;
        }

        public IEnumerable<int> GetNumbers(int maxNUmber = 100)
        {
            for (var i = 0; i < maxNUmber; i++)
            {
                Console.WriteLine("start iteration");
                yield return i;
                Console.WriteLine("end iteration");
            }
        }

        public class MyType
        {
            public IEnumerator<string> GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public class MyEnumerator : IEnumerator<string>
        {
            private string[] values = {""};

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public string Current { get; }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }


        public class TestEnumerableDuckTyping
        {
            private static readonly string[] Names = {"Name1", "Name2", "Name3"};

            //public IEnumerator GetEnumerator()
            public IEnumerator<string> GetEnumerator()
            {
                foreach (var o in Names)
                {
                    if (o == null) break;

                    yield return o;
                }
            }
        }

        public class TestEnumerable : IEnumerable<string>
        {
            private static readonly string[] Names = {"Name1", "Name2", "Name3"};

            // IEnumerable Member  
            public IEnumerator<string> GetEnumerator()
            {
                foreach (var o in Names)
                {
                    if (o == null) break;

                    yield return o;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}