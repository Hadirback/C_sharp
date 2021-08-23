using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _018_ObserverPattern
{
    /*
     Применимость
        Когда после изменения состояния одного объекта требуется что то сделать в других но вы не
        знаете наперед какие именно объекты должны отреагировать

        Когда одни объекты должны наблюдать за другими но только в определенных случаях.
     */
    class Program
    {

        static void Main(string[] args)
        {

            Subject subject = new Subject();

            var observerA = new ConcreteObserverA();
            subject.Attach(observerA);

            var observerB = new ConcreteObserverB();
            subject.Attach(observerB);

            subject.DoSomething();
            subject.DoSomething();

            subject.Detach(observerB);

            subject.DoSomething();

            Console.ReadLine();
        }
    }
}
