using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010_FacadePattern
{
    /*
     Применимость
        Когда вам нужно представить простой или урезанный интерфейс к сложной системе

        Когда вы хотите разложить подсистему на отдельные слои
     */
    class Program
    {
        static void Main(string[] args)
        {
            Client.ClientCode(new Facade(new Subsystem1(), new Subsystem2()));
            Console.ReadKey();
        }
    }

    class Client
    {
        public static void ClientCode(Facade facade)
        {
            Console.WriteLine(facade.Operation());
        }
    }
}
