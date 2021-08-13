using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TasksAndAsyncAwaitTest
{
    class Test1
    {
        public async Task MainTest1Meth()
        {
            Console.WriteLine($"ThreadId - {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"ContextID - {Thread.CurrentContext.ContextID}");

            Test1 pr = new Test1();

            var res1 = Task.Run(() => pr.DoSomething());
            res1.Wait();

            await pr.DoSomething2();
            Console.WriteLine("end");
        }

        private void DoSomething()
        {
            Console.WriteLine($"DoSomething ThreadId - {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"DoSomething Context ID - {Thread.CurrentContext.ContextID}");
            Task.Delay(4000);
        }

        private async Task DoSomething2()
        {
            Console.WriteLine($"DoSomethingAsync ThreadId - {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"DoSomethingAsync ContextID - {Thread.CurrentContext.ContextID}");
            await Task.Delay(4000);
        }
    }
}
