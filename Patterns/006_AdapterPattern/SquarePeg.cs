using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_AdapterPattern
{
    public class SquarePeg
    {
        public SquarePeg(int width)
        {
            Width = width;
        }

        public int Width { get; set; }
    }
}
