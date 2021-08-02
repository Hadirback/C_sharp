using _002_AbstractFactoryMethodPattern.Furniture.IFurniture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_AbstractFactoryMethodPattern.Furniture.Model.Chair
{
    class ModernChair : IChair
    {
        bool IChair.HasLegs()
        {
            Console.WriteLine("Modern Chair has 1 Leg");
            return true;
        }

        void IChair.SitOn()
        {
            Console.WriteLine("Sit down on Modern Chair");
        }
    }
}
