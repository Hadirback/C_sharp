using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _005_SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread pr1 = new Thread(() =>
            {
                TestSingeton("Foo");
            });

            Thread pr2 = new Thread(() =>
            {
                TestSingeton("Bar");
            });
            pr1.Start();
            pr2.Start();

            pr1.Join();
            pr2.Join();
            Console.ReadKey();

        }

        private static void TestSingeton(String str)
        {
            DatabaseSingleton singleton = DatabaseSingleton.GetInstance(str);
            Console.WriteLine(singleton.Value);
            Thread.Sleep(2000);
        }
    }
}
