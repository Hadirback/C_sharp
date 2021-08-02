using _001_FactoryMethodPattern.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_FactoryMethodPattern
{
    abstract class TransportFactory
    {
        public string Name { get; set; }

        public Int32 Number { get; set; }

        public TransportFactory(string name, Int32 number)
        {
            Name = name;
            Number = number;
        }

        public bool DoLoading()
        {
            ITransport transport = Create();
            
            transport.Deliver();

            return transport.CheckProduct();
        }

        abstract public ITransport Create();
    }

    class TruckCreator : TransportFactory
    {
        public Int32 Height { get; set; }

        public TruckCreator(string name, Int32 num, Int32 height) : this(name, num) 
        {
            Height = height;
        }
        public TruckCreator(string name, Int32 num) : base(name, num)
        {

        }

        public override ITransport Create()
        {
            return new Truck();
        }
    }

    class ShipCreator : TransportFactory
    {
        public Int32 Length { get; set; }

        public ShipCreator(string name, Int32 num, Int32 length) : this(name, num)
        {
            Length = length;
        }
        public ShipCreator(string name, Int32 num) : base(name, num)
        {

        }

        public override ITransport Create()
        {
            return new Ship();
        }
    }
}
