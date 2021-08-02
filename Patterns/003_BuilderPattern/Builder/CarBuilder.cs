
using _003_BuilderPattern.Model;
using _003_BuilderPattern.Model.ENums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_BuilderPattern.Builder
{
    public class CarBuilder : IBuilder
    {
        private Car car;

        public CarBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            car = new Car();
        }

        public void SetEngine(EngineEnum engine)
        {
            car.Engine = engine;
        }

        public void SetGps()
        {
            car.HasGps = true;
        }

        public void SetSeat(int number)
        {
            car.SetNumber = number;
        }

        public void SetTripComputer()
        {
            car.IsSetTripComputer = true;
        }

        public Car GetResult()
        {
            return car;
        }
    }
}
