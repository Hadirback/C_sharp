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
    public class ModernFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            Console.WriteLine("Create ModernChair");
            return new ModernChair();
        }

        public ICoffeeTable CreateCoffeeTable()
        {
            Console.WriteLine("Create ModernCoffeeTable");
            return new ModernCoffeeTable();
        }

        public ISofa CreateSofa()
        {
            Console.WriteLine("Create ModernSofa");
            return new ModernSofa();
        }
    }
}
