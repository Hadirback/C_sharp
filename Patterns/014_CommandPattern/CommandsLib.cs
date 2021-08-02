using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _014_CommandPattern
{
    public class ComplexCommand : ICommand
    {
        private String a;

        private String b;
        private Receiver receiver;

        public ComplexCommand(Receiver rec, string a, string b)
        {
            this.a = a;
            this.b = b;
            receiver = rec;
        }

        public void Execute()
        {
            Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver object.");
            this.receiver.DoSomething(this.a);
            this.receiver.DoSomethingElse(this.b);
        }
    }

}
