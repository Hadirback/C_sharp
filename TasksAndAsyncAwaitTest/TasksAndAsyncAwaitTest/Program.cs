using System;
using System.Collections.Generic;
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

            if (true)
            {
                Test3 test = new Test3();
                await test.MainTest3Meth();
            }

            Console.WriteLine($"Main thread {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadKey();
        }  
    }
}
