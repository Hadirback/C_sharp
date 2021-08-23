using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _017_MementoPattern
{
    /*
     Создатель содержит некоторое важное состояние которое может со временм меняться. Он также
    объявляет метод сохранения состяния внутри снимка и метод восстановления состояния из него
     */
    class Originator
    {
        private string state;

        public Originator(string state)
        {
            this.state = state;
            Console.WriteLine("Originator: My initial state is: " + state);
        }

        // Бизнес-логика создателя может повлиять на его внутреннее состояние.
        // поэтому клиент должен выполнить резервное копирование состояния с
        // помощью метода save перед запуском методов бизнес логики.

        public void DoSomething()
        {
            Console.WriteLine("Originator: I'm doing something important.");
            this.state = GenerateRandomString(30);
            Console.WriteLine($"Originator: and my state has changed to: {state}");
        }

        private string GenerateRandomString(int length = 10)
        {
            string allowedSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = string.Empty;

            while (length > 0)
            {
                result += allowedSymbols[new Random().Next(0, allowedSymbols.Length)];

                Thread.Sleep(12);

                length--;
            }

            return result;
        }

        public IMemento Save()
        {
            return new ConcreteMemento(this.state);
        }

        public void Restore(IMemento memento)
        {
            if(!(memento is ConcreteMemento))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }

            state = memento.GetState();
            Console.Write($"Originator: My state has changed to: {state}");
        }
    }
}
