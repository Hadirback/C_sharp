using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITVDN_Async_Programming
{
    internal class ValueTaskEx
    {
        public static void Run()
        {
            CalculateAndShowAsync(2).GetAwaiter().GetResult();
            Console.ReadKey();
        }

        public static void Run(int a, int b)
        {
            int res = Sum(a, b).Result;
            Console.WriteLine(res);
        }

        public static void Go()
        {
            int salary = 4000;
            ValueTask<double> valueTask = GetIndexing(salary);

            while (!valueTask.IsCompleted)
            {
                Console.WriteLine('*'); 
                Thread.Sleep(200);
            }

            Task<double> task = valueTask.AsTask();
            task.ContinueWith((t) => Console.WriteLine($"Индексация зарплаты {salary} = {t.Result}%"));

        }

        private static ValueTask<double> GetIndexing(int salary)
        {
            Thread.Sleep(500);

            if(salary <= 0)
            {
                return new ValueTask<double>(0);
            }
            else if(salary > 5000)
            {
                return new ValueTask<double>(0);
            }
            else if(salary == 5000)
            {
                return new ValueTask<double>(0.1);
            }
            else
            {
                return new ValueTask<double>(Task.Run(() =>
                {
                    double index = 0.0;
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(500);
                        index += 0.1;
                    }

                    return index;
                }));
            }
        }

        private static ValueTask<int> Sum(int a, int b)
        {
            if (a == 0)
            {
                return new ValueTask<int>(b);
            }
            else if(b == 0) 
            {
                return new ValueTask<int>(a);
            }
            else if(a == 0 && b == 0)
            {
                return new ValueTask<int>(0);
            }
            else
            {
                return new ValueTask<int>(Task.Run(() => { return a + b; }));
            }
        }

        private static ValueTask CalculateAndShowAsync(int ceiling)
        {
            if(ceiling < 0)
            { 
                return new ValueTask();
            }
            else
            {
                return new ValueTask(Task.Run(() =>
                {
                    Calculator(ceiling);
                }));
            }
        }

        private static void Calculator(int ceiling)
        {
            Console.WriteLine(ceiling);
        }
    }
}
