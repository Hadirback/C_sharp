using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_CompositePattern
{
    public class Circle : Dot
    {
        private int radius;
        public Circle(int x, int y, int radius)
            : base(x, y)
        {
            this.radius = radius;
        }

        public new void Draw()
        {
            Console.WriteLine($"Нарисовать круг в координатах X:{x} Y:{y} с радиусом {radius}");
        }
    }
}
