using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_FactoryMethodPattern.Transport
{
    class Ship : ITransport
    {
        public bool CheckProduct()
        {
            Console.WriteLine("Все продукты на корабле");
            return true;
        }

        public void Deliver()
        {
            Console.WriteLine("Судно было отправлено");
        }
    }
}
