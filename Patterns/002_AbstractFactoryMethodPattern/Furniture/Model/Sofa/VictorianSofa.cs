using _002_AbstractFactoryMethodPattern.Furniture.IFurniture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_AbstractFactoryMethodPattern.Furniture.Model.Sofa
{
    class VictorianSofa : ISofa
    {
        public bool IsHard()
        {
            Console.WriteLine("VictorianSofa is not Hard");
            return false;
        }

        public void Sleep()
        {
            Console.WriteLine("We sleep on the VictorianSofa");
        }
    }
}
