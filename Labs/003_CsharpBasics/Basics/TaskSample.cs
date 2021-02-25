using System.Threading;
using System.Threading.Tasks;

namespace Basics
{
    public class TaskSample
    {
        public TaskSample()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            Task.Factory.StartNew(MySuperMethod,
                TaskCreationOptions.LongRunning, 
                cancellationTokenSource.Token);

            cancellationTokenSource.Cancel();
        }

        public void MySuperMethod(object argument)
        {
            //return Task.CompletedTask;
        }
    }
}