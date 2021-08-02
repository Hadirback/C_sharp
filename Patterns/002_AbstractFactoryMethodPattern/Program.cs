using _002_AbstractFactoryMethodPattern.AbstractFactory;
using _002_AbstractFactoryMethodPattern.Furniture.IFurniture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_AbstractFactoryMethodPattern
{
    class Program
    {
        /*
         Применимость:
            Логика должна работать с разными видами связанных продуктов, 
            не завися от конкретных классов

            Может быть трансформирован из Фабричного паттерна
         */

        static void Main(string[] args)
        {
            IFurnitureFactory configVictorian = new VictorianFurnitureFactory();
            TestMethod(CreateThreeModels(configVictorian));

            Console.WriteLine("------------------------");

            IFurnitureFactory configModern = new ModernFurnitureFactory();
            TestMethod(CreateThreeModels(configModern));

            Console.ReadKey();
        }

        public static (IChair chair, ICoffeeTable coffeeTable, ISofa sofa) CreateThreeModels(IFurnitureFactory factory)
        {
            return (factory.CreateChair(), factory.CreateCoffeeTable(), factory.CreateSofa());
        }

        public static void TestMethod((IChair chair, ICoffeeTable coffeeTable, ISofa sofa) complect)
        {
            complect.chair.HasLegs();
            complect.chair.SitOn();

            complect.coffeeTable.HasMirror();
            complect.coffeeTable.PutInCenterRoom();

            complect.sofa.IsHard();
            complect.sofa.Sleep();
        }
    }
}
