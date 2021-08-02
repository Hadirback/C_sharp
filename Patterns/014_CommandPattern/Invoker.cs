using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _014_CommandPattern
{
    public class Invoker
    {
        private ICommand onStart;
        private ICommand onFinish;

        public void SetOnStart(ICommand command)
        {
            this.onStart = command;
        }
        public void SetOnFinish(ICommand command)
        {
            this.onFinish = command;
        }

        public void DoSomethingImportant()
        {
            Console.WriteLine("Invoker: Does anybody want something done before I begin?");
            if (this.onStart is ICommand)
            {
                this.onStart.Execute();
            }

            Console.WriteLine("Invoker: ...doing something really important...");

            Console.WriteLine("Invoker: Does anybody want something done after I finish?");
            if (this.onFinish is ICommand)
            {
                this.onFinish.Execute();
            }
        }
    }
}
