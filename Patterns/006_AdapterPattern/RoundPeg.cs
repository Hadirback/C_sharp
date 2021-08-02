using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_AdapterPattern
{
    public class RoundPeg
    {

        public RoundPeg()
        {
            Radius = 0;
        }
        public RoundPeg(int radius)
        {
            Radius = radius;
        }

        public int Radius { get; set; }


    }
}
