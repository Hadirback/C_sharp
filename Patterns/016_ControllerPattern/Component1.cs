using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _016_ControllerPattern
{
    class Component1 : BaseComponent
    {

        public void DoA()
        {
            Console.WriteLine("Comp 1 does A");
            this.mediator.Notify(this, "A");
        }

        public void DoB()
        {
            Console.WriteLine("Comp1 does B");
            this.mediator.Notify(this, "B");
        }
    }


}
