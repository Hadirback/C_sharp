using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020_StrategyPattern
{
    /*
     Применимость
        Когда вам нужно использовать разные вариации какого то алгоритма внутри одного объекта.

        Когда у вас есть множество похожих классов отличающихся только некоторым поведением.

        Когда вы не хотите обнажать детали реализации алгоритмов для других классов.

        Когда различные вариации аолгритмов реализованы в виде развестстого услового оператора. 
        Каждая ветка такого оператора продестваляет собой вариацию алгоритма.
     */
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();

            Console.WriteLine("Client: Strategy is set to normal sorting.");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomething();

            Console.WriteLine();

            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomething();

            Console.ReadLine();
        }
    }
}
