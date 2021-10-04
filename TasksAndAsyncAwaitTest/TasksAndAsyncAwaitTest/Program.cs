using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TasksAndAsyncAwaitTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if(false)
            {
                Test1 test = new Test1();
                await test.MainTest1Meth();
            }

            if (false)
            {
                Test2 test = new Test2();
                await test.MainTest2Meth();
            }

            if (false)
            {
                Test3 test = new Test3();
                await test.MainTest3Meth();
            }
            Console.WriteLine($"Main thread {Thread.CurrentThread.ManagedThreadId}");
            if (true)
            {
                Test4_Yield test = new Test4_Yield();
                await test.TestMethod();
            }

            if (true)
            {  
                String sdf = await GetSomeDataAsync();
            }

            Console.WriteLine($"Main thread {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadKey();
        }

        public static Task<string> GetSomeDataAsync()
        {
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
            FileSystemWatcher watcher = new FileSystemWatcher
            {
                Path = Directory.GetCurrentDirectory(),
                NotifyFilter = NotifyFilters.LastAccess,
                EnableRaisingEvents = true
            };
            watcher.Changed += (o, e) => tcs.SetResult(e.FullPath);
            return tcs.Task;
        }
    }
}
