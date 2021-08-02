using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITVDN_Async_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            if (false)
            {
                Console.WriteLine("Press any key");
                Console.ReadKey();

                ThreadPoolWorker threadPoolWorker = new ThreadPoolWorker(new Action<object>(StartWriter));
                threadPoolWorker.Start('*');

                for (int i = 0; i < 40; i++)
                {
                    Console.WriteLine("-");
                    Thread.Sleep(50);

                }

                threadPoolWorker.Wait();
                Console.WriteLine("Method Main ended!");
            }

            if(false)
            {
                Console.WriteLine("Press any key");
                Console.ReadKey();
                TPWorker<int> tPWorker = new TPWorker<int>(SumNumber);
                tPWorker.Start(1000);

                while(tPWorker.Completed == false)
                {
                    Console.Write("*");
                    Thread.Sleep(35);
                }

                Console.WriteLine();
                Console.WriteLine($"result = {tPWorker.Result:N}");
            }


            if (false)
            {
                ValueTaskEx.Run();

            }

            if (false)
            {
                ValueTaskEx.Run(0, 3);
            }

            if (true)
            {
                ValueTaskEx.Go();
            }

            Console.ReadLine();
        }

        private static void StartWriter(object arg)
        {
            char item = (char)arg;

            for (int i = 0; i < 120; i++)
            {
                Console.Write(item);
                Thread.Sleep(50);
            }
        }

        private static int SumNumber(object arg)
        {
            int number = (int)arg;
            int sum = 0;

            for (int i = 0; i < number; i++)
            {
                sum += i;
                Thread.Sleep(1);
            }

            return sum;
        }

    }
}
