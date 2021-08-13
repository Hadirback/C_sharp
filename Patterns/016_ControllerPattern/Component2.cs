using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _016_ControllerPattern
{
    class Component2 : BaseComponent
    {
        public void DoC()
        {
            Console.WriteLine("Comp 2 does C");
            this.mediator.Notify(this, "C");
        }

        public void DoD()
        {
            Console.WriteLine("Comp 2 does D");
            this.mediator.Notify(this, "D");
        }
    }
}
