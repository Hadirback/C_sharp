using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_PrototypePattern
{
    class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(int id)
            :base(id)
        {

        }

        public override Prototype Clone()
        {
            return new ConcretePrototype1(Id);
        }
    }

    class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(int id)
            : base(id)
        {

        }

        public override Prototype Clone()
        {
            return new ConcretePrototype1(Id);
        }
    }
}
