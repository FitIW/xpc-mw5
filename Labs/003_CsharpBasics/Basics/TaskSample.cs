using System;
using System.Threading;
using System.Threading.Tasks;

namespace Basics
{
    public class TaskSample
    {

        public async Task MyAsyncMethod()
        {

            await MyBlockingOperation();
            return;
        }

        public Task MyBlockingOperation() => Task.CompletedTask;

        public void MySuperMethod(object argument)
        {
            return;
            //return Task.CompletedTask;
        }

        public async Task Run()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            Task.Factory.StartNew(MySuperMethod,
                TaskCreationOptions.LongRunning,
                cancellationTokenSource.Token);

            cancellationTokenSource.Cancel();

            var myClass = new MyClass();

            Console.WriteLine("before async method call");

            await myClass.MyAsyncMethod(4);
            await myClass.MyAsyncMethod(1);
            await myClass.MyAsyncMethod(2);
            await myClass.MyAsyncMethod(3);
            await Task.CompletedTask;
            Console.WriteLine("after async method call");
        }

        private class MyClass
        {
            public async Task<string> MyAsyncMethod(int number)
            {
                await Task.Delay(100 * number);
                Console.WriteLine($"Hello from async - {number}");
                await MyBlockingOperation();
                return "asdas";
            }

            public Task MyBlockingOperation()
            {
                return Task.CompletedTask;
            }
        }
    }
}