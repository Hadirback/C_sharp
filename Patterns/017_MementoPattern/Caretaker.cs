using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _017_MementoPattern
{
    // Опекун не зависит от класса конкретного снимка. Таким образом он не имеет доступа к состоянию
    // создателя, хранящемуся внутри снимка. Он работает со всеми снимками через базовый интерфейс.
    class Caretaker
    {
        private List<IMemento> mementos = new List<IMemento>();

        private Originator originator = null;

        public Caretaker(Originator originator)
        {
            this.originator = originator;
        }

        public void Backup()
        {
            Console.WriteLine("\nCaretaker: Saving Originator's state...");
            mementos.Add(originator.Save());
        }

        public void Undo()
        {
            if(mementos.Count == 0)
            {
                return;
            }

            var memento = this.mementos.Last();
            mementos.Remove(memento);

            Console.WriteLine("Caretaker: Restoring state to: " + memento.GetName());

            try
            {
                originator.Restore(memento);
            }
            catch (Exception ex)
            {
                this.Undo();
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine("Caretaker: Here's the list of mementos:");

            foreach (var memento in this.mementos)
            {
                Console.WriteLine(memento.GetName());
            }
        }
    }
}
