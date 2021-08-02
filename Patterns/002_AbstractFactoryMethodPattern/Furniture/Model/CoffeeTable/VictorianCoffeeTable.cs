using _002_AbstractFactoryMethodPattern.Furniture.IFurniture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_AbstractFactoryMethodPattern.Furniture.Model.CoffeeTable
{
    class VictorianCoffeeTable : ICoffeeTable
    {
        public bool HasMirror()
        {
            Console.WriteLine("VictorianCoffeeTable haven't mirror");
            return false;
        }

        public void PutInCenterRoom()
        {
            Console.WriteLine("Put VictorianCoffeeTable in center");
        }
    }
}
