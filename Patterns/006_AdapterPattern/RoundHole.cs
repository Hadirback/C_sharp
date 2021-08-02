using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_AdapterPattern
{
    public class RoundHole
    {
        public RoundHole(int radius)
        {
            Radius = radius;
        }

        public int Radius { get; set; }

        public Boolean Fits(RoundPeg roundPeg)
        {
            return Radius >= roundPeg.Radius;
        }
    }
}
