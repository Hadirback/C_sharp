using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015_IteratorPattern
{
    class Program
    {
        /*
         Применимость

            Когда у вас есть сложная структура данных и вы хотите скрыть от клиента
            детали ее реализации

            Когда вам нужно иметь несколько вариантов обхода одной и той же структры данных

            Когда вам хочется иметь единый интерфейс обхода различных структур данных
         */
        static void Main(string[] args)
        {
            var coll = new WordsCollection();
            coll.AddItem("First");
            coll.AddItem("Second");
            coll.AddItem("Third");

            Console.WriteLine("Straight traversal:");
            foreach (var elem in coll)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine("\nReverse traversal:");

            coll.ReverseDirection();
            foreach (var elem in coll)
            {
                Console.WriteLine(elem);
            }

            Console.ReadLine();
        }
    }
}
