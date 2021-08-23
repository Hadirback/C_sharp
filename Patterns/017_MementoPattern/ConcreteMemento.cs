using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _017_MementoPattern
{
    class ConcreteMemento : IMemento
    {
        private string state;

        private DateTime date;

        public ConcreteMemento(string state)
        {
            this.state = state;
            date = DateTime.Now;
        }

        public DateTime GetDate()
        {
            return date;
        }

        public string GetName()
        {
            return $"{this.date} / ({this.state.Substring(0, 9)})...";
        }

        public string GetState()
        {
            return this.state;
        }
    }
}
