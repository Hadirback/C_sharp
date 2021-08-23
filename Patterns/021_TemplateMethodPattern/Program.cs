using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _021_TemplateMethodPattern
{
    class Program
    {
        /*
         Применимость
            Когда подклассы должны расширять базовый алгоритм не меняя его структуры

            Когда у вас есть несколько классов, делающих одно и то же с незначительными отличиями. Если 
            отредактировать один класс то приходтися вносить также правки и в остальные классы.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Same client code can work with different subclasses:");
            Client.ClientCode(new ConcreteClass1());
            Console.WriteLine();

            Console.WriteLine("Same client code can work with different subclasses:");
            Client.ClientCode(new ConcreteClass2());

            Console.ReadLine();
        }
    }
}
