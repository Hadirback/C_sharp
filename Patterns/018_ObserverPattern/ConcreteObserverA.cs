using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _018_ObserverPattern
{
    class ConcreteObserverA : IObserver
    {
        public void Update(ISubject subject)
        {
            if((subject as Subject).State < 3)
            {
                Console.WriteLine("ConcreteObserverA: Reacted to the event.");
            }
        }
    }
}
