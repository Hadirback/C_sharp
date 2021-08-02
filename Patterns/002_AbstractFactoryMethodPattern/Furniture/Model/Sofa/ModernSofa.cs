using _002_AbstractFactoryMethodPattern.Furniture.IFurniture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_AbstractFactoryMethodPattern.Furniture.Model.Sofa
{
    class ModernSofa : ISofa
    {
        public bool IsHard()
        {
            Console.WriteLine("ModernSofa is Hard");
            return true;
        }

        public void Sleep()
        {
            Console.WriteLine("We sleep on the ModernSofa");
        }
    }
}
