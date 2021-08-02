using _002_AbstractFactoryMethodPattern.Furniture.IFurniture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_AbstractFactoryMethodPattern.Furniture.Model.CoffeeTable
{
    class ModernCoffeeTable : ICoffeeTable
    {
        public bool HasMirror()
        {
            Console.WriteLine("ModernCoffeeTable has mirror");
            return true;
        }

        public void PutInCenterRoom()
        {
            Console.WriteLine("It depends for ModernCoffeeTable");
        }
    }
}
