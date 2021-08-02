using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_AbstractFactoryMethodPattern.Furniture.IFurniture
{
    public interface ICoffeeTable
    {
        bool HasMirror();

        void PutInCenterRoom();
    }
}
