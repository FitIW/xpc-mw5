using System;

namespace Basics
{
    public class Disposable : ISample
    {
        public void Run()
        {
            try
            {
                var obj = new MyDisposableObject();
                try
                {
                    obj.MethodThatThrowException();
                }
                finally
                {
                    obj.Dispose();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                using (var obj = new MyDisposableObject())
                {
                    obj.MethodThatThrowException();
                    Console.WriteLine("in using block");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
            //Console.WriteLine("out using block");

        }

        public class MyDisposableObject : IDisposable
        {
            public void MethodThatThrowException()
            {
                throw new Exception("exception in using"); ;
            }
            public MyDisposableObject()
            {
                throw new Exception("exception in ctor");
            }
            public void Dispose()
            {
                Console.WriteLine($"{nameof(MyDisposableObject)} object was disposed");
            }
        }
    }
}