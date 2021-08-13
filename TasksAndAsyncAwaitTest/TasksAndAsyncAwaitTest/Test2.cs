using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TasksAndAsyncAwaitTest
{
    class Test2
    {
        public async Task MainTest2Meth()
        {
            Console.WriteLine($"Start main {Thread.CurrentThread.ManagedThreadId}");

            Task task = MethodAsync();
            int sum = 0;
            Console.WriteLine($"Start for {Thread.CurrentThread.ManagedThreadId}");

            for (int i = 0; i < 100; i++)
            {
                sum += i;
                await Task.Delay(100);
            }

            Console.WriteLine($"End for {Thread.CurrentThread.ManagedThreadId}");
            await task;
            Console.WriteLine($"after await task {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task MethodAsync()
        {
            Console.WriteLine($"Method Async Start {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(4000);
            Console.WriteLine($"Method Async End {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
