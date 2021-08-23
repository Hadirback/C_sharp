using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _017_MementoPattern
{
    /*
     Применимость
        Когда вам нужно сохранять мгновенные снимка состояния объекта чтобы впоследствии объект можно было
        восстановить в том же состоянии.

        Когда прямое получение состояния объекта раскрывает приватные детали его реализации, нарушая инкапсуляцию
     */
    class Program
    {
        static void Main(string[] args)
        {

            Originator originator = new Originator("Super-duper-super-puper-super.");

            Caretaker caretaker = new Caretaker(originator);

            caretaker.Backup();

            originator.DoSomething();

            caretaker.Backup();

            originator.DoSomething();

            caretaker.Backup();

            originator.DoSomething();
            Console.WriteLine();

            caretaker.ShowHistory();

            Console.WriteLine("\nClient: Now, let's rollback!\n");
            caretaker.Undo();

            Console.WriteLine("\n\nClient: Once more!\n");
            caretaker.Undo();

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
