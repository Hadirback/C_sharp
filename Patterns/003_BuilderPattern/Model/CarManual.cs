using _003_BuilderPattern.Model.ENums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_BuilderPattern.Model
{
    public class CarManual
    {
        public Int32 SetNumber { get; set; }

        public EngineEnum Engine { get; set; }

        public Boolean IsSetTripComputer { get; set; }

        public Boolean HasGps { get; set; }

        public override String ToString()
        {
            return $"Seat - {SetNumber}, Engine - {Engine}, \n" +
                $"IsSetTripComputer - {IsSetTripComputer}, HasGps - {HasGps}";
        }
    }
}
