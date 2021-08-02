using _003_BuilderPattern.Builder;
using _003_BuilderPattern.Model.ENums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_BuilderPattern
{
    public class Director
    {
        public void ConstructCar(IBuilder builder)
        {
            switch (builder)
            {
                case CarManualBuilder cmb:
                    cmb.SetSeat(4);
                    cmb.SetEngine(EngineEnum.Engine8L);
                    cmb.SetTripComputer();
                    cmb.SetGps();
                    break;
                case CarBuilder cb:
                    cb.SetSeat(6);
                    cb.SetEngine(EngineEnum.Engine2L);
                    cb.SetTripComputer();
                    cb.SetGps();
                    break;
                default:
                    break;
            }
        }
    }
}
