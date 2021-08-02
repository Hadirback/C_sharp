using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _014_CommandPattern
{
    public class Program
    {
        /*
         Применимость

            Когда вы хотите параметризовать объект выполняемым действием.

            Когда вы хотите ставить операции в очередь, выполняя их по рассписанию или передавать по сети

            Когда вам нужна операция отмены
         */
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();

            invoker.SetOnStart(new SimpleCommand("Say Hi!"));
            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver, "Send Email", "Save report"));

            invoker.DoSomethingImportant();

            Console.ReadLine();
        }

    }
}
