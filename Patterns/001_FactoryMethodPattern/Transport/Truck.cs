using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_FactoryMethodPattern.Transport
{
    class Truck : ITransport
    {
        public bool CheckProduct()
        {
            Console.WriteLine("Не все продукты в грузовике");
            return false;
        }

        public void Deliver()
        {
            Console.WriteLine("Грузовик отправлен в путь");
        }
    }
}
