using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _016_ControllerPattern
{
    class ConcreteMediator : IMediator
    {
        private Component1 component1;

        private Component2 component2;

        public ConcreteMediator(Component1 component1, Component2 component2)
        {
            this.component1 = component1;
            this.component1.SetMediator(this);

            this.component2 = component2;
            this.component2.SetMediator(this);
        }

        public void Notify(object sender, string ev)
        {
            if(ev == "A")
            {
                Console.WriteLine("Mediator reacts on A and triggers following operations:");
                this.component2.DoC();
            }
            if(ev == "D")
            {
                Console.WriteLine("Mediator reacts on D and triggers following operations:");
                this.component1.DoB();
                this.component2.DoC();
            }
        }

    }
}
