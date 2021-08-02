using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_AdapterPattern
{
    public class Common
    {
        public Common()
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine(target.GetRequest());
        }
        
    }

    // Целевой класс объявляет интерфейс с котоорым может работать клиентский код
    public interface ITarget
    {
        String GetRequest();
    }

    // Адаптируемый класс содержит некоторое полезное поведение но его интерфейс
    // не совместим с существующий клиентским кодом. Адаптируемый класс нуждается в 
    // в некоторой доработке прожде чем клиентский код сможет его использовать
    public class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request";
        }
    }

    // Адаптер делает интерфейс адаптируемого класса совместимым с целевым интерфейсом
    public class Adapter : ITarget
    {
        private readonly Adaptee adaptee;

        public Adapter(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is {this.adaptee.GetSpecificRequest()}";
        }
    }
}
