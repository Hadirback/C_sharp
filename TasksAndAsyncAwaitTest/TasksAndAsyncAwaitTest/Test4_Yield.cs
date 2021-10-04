using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TasksAndAsyncAwaitTest
{
    class Test4_Yield
    {
        public async Task TestMethod()
        {
            Console.WriteLine($"current SC - {SynchronizationContext.Current}");


            Task task = Task.Delay(3000);
            Console.WriteLine($"current SC 2 - {SynchronizationContext.Current}");
            Console.WriteLine($"Main thread 2 {Thread.CurrentThread.ManagedThreadId}");
            await task;
            await Task.Yield();
            
            Console.WriteLine($"Main thread 3 {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"current SC 3 - {SynchronizationContext.Current}");
        }
    }
}
