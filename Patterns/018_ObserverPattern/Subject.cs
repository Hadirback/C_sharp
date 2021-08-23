using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _018_ObserverPattern
{
    // Издатель владеет некоторым важным состоянием и оповещает наблюдателей о его изменениях
    public class Subject : ISubject
    {
        // Для удобства в этой переменной хранится состоняие издателя, необходимое всем подписчикам
        public int State { get; set; } = -1;

        private List<IObserver> observers = new List<IObserver>();


        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");
            foreach (var observer in observers)
            {
                observer.Update(this);
            }
        }

        // Бизнес логика издатели часто содержат некоторую важную логику которая запускает метод уведомления всякий
        // раз кода должно произойти что то важное
        public void DoSomething()
        {
            Console.WriteLine("\nSubject: I'm doing something important.");
            State = new Random().Next(0, 10);

            Thread.Sleep(15);
            Console.WriteLine("Subject: My state has just changed to: " + this.State);
            Notify();

        }
    }
}
