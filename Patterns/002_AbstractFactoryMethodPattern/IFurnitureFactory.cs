using _002_AbstractFactoryMethodPattern.Furniture.IFurniture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_AbstractFactoryMethodPattern
{
    public interface IFurnitureFactory
    {
        IChair CreateChair();

        ICoffeeTable CreateCoffeeTable();

        ISofa CreateSofa();
    }
}
