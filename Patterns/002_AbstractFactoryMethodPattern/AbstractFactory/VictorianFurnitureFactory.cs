using _002_AbstractFactoryMethodPattern.Furniture.IFurniture;
using _002_AbstractFactoryMethodPattern.Furniture.Model.Chair;
using _002_AbstractFactoryMethodPattern.Furniture.Model.CoffeeTable;
using _002_AbstractFactoryMethodPattern.Furniture.Model.Sofa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_AbstractFactoryMethodPattern.AbstractFactory
{
    public class VictorianFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            Console.WriteLine("Create VictorianChair");
            return new VictorianChair();
        }

        public ICoffeeTable CreateCoffeeTable()
        {
            Console.WriteLine("Create VictorianCoffeeTable");
            return new VictorianCoffeeTable();
        }

        public ISofa CreateSofa()
        {
            Console.WriteLine("Create VictorianSofa");
            return new VictorianSofa();
        }
    }
}
