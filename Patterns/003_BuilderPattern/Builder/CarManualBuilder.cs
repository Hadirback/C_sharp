using _003_BuilderPattern.Model;
using _003_BuilderPattern.Model.ENums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_BuilderPattern.Builder
{
    public class CarManualBuilder : IBuilder
    {
        private CarManual car;

        public CarManualBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            car = new CarManual();
        }

        public void SetEngine(EngineEnum engine)
        {
            car.Engine = engine;
        }

        public void SetGps()
        {
            car.HasGps = false;
        }

        public void SetSeat(int number)
        {
            car.SetNumber = number;
        }

        public void SetTripComputer()
        {
            car.IsSetTripComputer = false;
        }

        public CarManual GetResult()
        {
            return car;
        }
    }
}
