using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Basics
{
    public class Exceptions : ISample
    {
        private string myField;
        public void MySuperMethod(string test)
        {
            myField = test ?? throw new ArgumentNullException(nameof(test));

            //if (test == null)
            //{
            //    throw new ArgumentNullException(nameof(test));
            //}

            //var test2 = myArg ?? throw new ArgumentNullException("");
        }

        public void Run()
        {

            string test = null;

            //try catch finally
            try
            {
                throw MySecretException.Create(new FileNotFoundException("file test not found"));
                //throw MySecretException.Create();

                MySuperMethod(null);
                Console.WriteLine("int try");
            }
            catch (MySecretException e)
            {
                //Console.WriteLine("have inner exception");
                //var exception = new Exception("my exception");
                var exception = new Exception("my exception", e);
                throw exception;
                //Console.WriteLine("exception will be throw");
                //throw;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                //var exception = new Exception("", e);
                //throw exception;
                throw;
            }
            finally
            {
                Console.WriteLine("finally");
            }


            try
            {
                throw new MySecretException("");
            }
            catch (MySecretException e) when (e.Message.Contains("haha"))
            {
                Console.WriteLine(e);
                throw;
            }
            catch (MySecretException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public class MySecretException : Exception
        {
            public bool HaveInnerException { get; set; }
            public MySecretException(string message) : base(message)
            {
                HaveInnerException = false;
            }

            public MySecretException(string message, Exception innerException) : base(message, innerException)
            {
                HaveInnerException = true;
            }

            public static MySecretException Create(string message = "")
            {
                return new MySecretException($"My secret exception is here: {message}");
            }
            public static MySecretException Create(Exception innerException)
            {
                return new MySecretException("My secret exception is here", innerException);
            }
        }
    }
}