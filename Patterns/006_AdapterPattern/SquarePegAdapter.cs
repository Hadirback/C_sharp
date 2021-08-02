using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_AdapterPattern
{
    public class SquarePegAdapter : RoundPeg
    {
        private SquarePeg peg;

        public SquarePegAdapter(SquarePeg peg)
        {
            this.peg = peg;
            this.Radius = (Int32)getRadius();
        }


        public double getRadius()
        {
            return peg.Width * Math.Sqrt(2) / 2;
        }
    }
}
