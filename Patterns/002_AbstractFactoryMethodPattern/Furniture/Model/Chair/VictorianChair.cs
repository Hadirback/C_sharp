using _002_AbstractFactoryMethodPattern.Furniture.IFurniture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_AbstractFactoryMethodPattern.Furniture.Model.Chair
{
    class VictorianChair : IChair
    {
        bool IChair.HasLegs()
        {
            Console.WriteLine("Victorian Chair has 4 Leg");
            return true;
        }

        void IChair.SitOn()
        {
            Console.WriteLine("Sit down on Victorian Chair");
        }
    }
}
