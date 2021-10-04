using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectManinulationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListRefTest.Run();

            //StaticClassManipulationTest.Run();

            //DoublePispatchTest.Run();

            //A test = new B();
            //test.Method();
            //EnumerableTest.Run();
            //EnumerableTest.Run2();

            //Test t = new Test();
            //Console.WriteLine(t.Run("dot", "ddot"));

            //TestAsyncAwait.Run().GetAwaiter();

            GetTest.Run();

            Console.ReadKey();

        }


        class TestAsyncAwait
        { 
            public static async Task Run()
            {
                Console.WriteLine(DateTime.Now);
                var first = DoDelay(5000);
                var second = DoDelay(10000);
                Console.WriteLine(DateTime.Now);

                await Task.WhenAll(first, second);
                Console.WriteLine(DateTime.Now);
            }

            public static async Task DoDelay(int time)
            {
                await Task.Delay(time);
            }
        }

        class GetTest
        {
            public static object locker = new object();
            public static async void Run()
            {
                try
                {
                    Console.WriteLine("start Run");
                    Monitor.Enter(locker);
                    Console.WriteLine("before GetDelay");
                    await GetDelay();

                    Console.WriteLine("after GetDelay");

                }
                catch(Exception ex)
                {
                    Console.WriteLine($"catch {ex}");
                    Monitor.Exit(locker);
                }
                finally
                {
                    Monitor.Exit(locker);
                }
                
            }

            public async static Task GetDelay()
            {
                Console.WriteLine("GetDelay");
                await Task.Delay(1000);
            }
        }

        class EnumerableTest
        {

            public static void Run()
            {
                try
                {

                    var result = RepeatString5Times(null);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            public static void Run2()
            {
                try
                {
                    var result = RepeatString5Times("test");
                    var firstItem = result.First();
                    var second = result.Count();
                    Console.WriteLine($"{firstItem}, {second}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            private static IEnumerable<string> RepeatString5Times(string toRepeat)
            {
                if (toRepeat == null)
                    throw new ArgumentNullException(nameof(toRepeat));
                for (int i = 0; i < 5; i++)
                {
                    if (i == 3)
                        throw new InvalidOperationException("3 is a horrible number");
                    yield return $"{toRepeat} - {i}";
                }
            }
        }

        class A
        {
            public A()
            {
                Console.WriteLine("A ctor");
                Method();
            }

            public virtual void Method()
            {
                Console.WriteLine("A class");
            }
        }


        class B : A
        {
            public B()
            {
                Console.WriteLine("B ctor");
            }
            public override void Method()
            {
                Console.WriteLine("B class");
            }
        }
    }



}
