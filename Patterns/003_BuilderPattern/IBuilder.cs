using _003_BuilderPattern.Model.ENums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_BuilderPattern
{
    public interface IBuilder
    {
        void Reset();

        void SetSeat(int number);

        void SetEngine(EngineEnum engine);

        void SetTripComputer();

        void SetGps();
    }
}
