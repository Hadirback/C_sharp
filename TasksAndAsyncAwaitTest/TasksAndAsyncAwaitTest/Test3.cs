using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAndAsyncAwaitTest
{
    class Test3
    {
        public async Task MainTest3Meth()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("Кофе готово");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = MakeToastWithButterAndJamAsync(2);

            Egg eggs = await eggsTask;
            Console.WriteLine("Яйца готовы");

            Bacon bacon = await baconTask;
            Console.WriteLine("Бекон готов");

            Toast toast = await toastTask;
            Console.WriteLine("Тост готов");

            Juice oj = PourOJ();
            Console.WriteLine("Сок готов");

            Console.WriteLine("Завтрак готов!");
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Налить апельсиновый сок");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Добавить джем к тосту");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Положить масло на тостер");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Положить ломтик хлеба в тостер");
            }
            Console.WriteLine("Ждать приготовления 3 сек...");
            await Task.Delay(3000);
            Console.WriteLine("Вытащить ломтик из тостера");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"Положить {slices} ломтика бекона на сковородку");
            Console.WriteLine("Готовить первую сторону ломтиков 3 сек...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Повернуть ломтик бекона");
            }
            Console.WriteLine("Готовить вторую сторону ломтиков 3 сек...");
            await Task.Delay(3000);
            Console.WriteLine("Положить бекон на тарелку");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Помыть яйца ожидать 3 сек...");
            await Task.Delay(3000);
            Console.WriteLine($"Сломать {howMany} яйца");
            Console.WriteLine("Готовить яйца 3 сек ...");
            await Task.Delay(3000);
            Console.WriteLine("Положить яйца в тарелку");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Приготовить кофе");
            return new Coffee();
        }
    }


    internal class Coffee
    {
    }

    internal class Egg
    {
    }

    internal class Bacon
    {
    }

    internal class Toast
    {
    }

    internal class Juice
    {
    }
}
