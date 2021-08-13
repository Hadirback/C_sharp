using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _016_ControllerPattern
{
    class Program
    {
        /*
         Применимость
            Когда вам сложно менять некоторые классы из за того что они имеют множество хаотичных связей
            с другими классами

            Когда вы не можете повторно использовать класс поскольку он зависит от уймы других
            классов

            Когда вам приходится создавать множество подклассов компонентов, чтобы использовать одни и те
            же компоненты в разных контексах.

         */
        static void Main(string[] args)
        {

            Component1 component1 = new Component1();
            Component2 component2 = new Component2();

            new ConcreteMediator(component1, component2);

            Console.WriteLine("Client triggets operation A");

            component1.DoA();

            Console.WriteLine("Client triggers operation D");
            component2.DoD();

            Console.ReadLine();
        }
    }
}
