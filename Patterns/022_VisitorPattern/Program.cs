using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _022_VisitorPattern
{
    class Program
    {
        /*
         Применимость
            Когда вам нужно выполнить какую то операцию над всеми элементами сложной структуры объектов например деревом
            
            Когда над объектами сложной структуры объектов надо выполнять некоторые не связанные между собой операции, 
            но вы не хотите засорять классы такими опреациями.

            Когда новое поведение имеет смысл только для некоторых классов из существующей иерархии.
        */
        static void Main(string[] args)
        {
            List<IComponent> components = new List<IComponent>
            {
                new ConcreteComponentA(),
                new ConcreteComponentB()
            };

            Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
            var visitor1 = new ConcreteVisitor1();
            Client.ClientCode(components, visitor1);

            Console.WriteLine();

            Console.WriteLine("It allows the same client code to work with different types of visitors:");
            var visitor2 = new ConcreteVisitor2();
            Client.ClientCode(components, visitor2);

            Console.ReadLine();

        }
    }
}
