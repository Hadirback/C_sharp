using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_CompositePattern
{
    public class Dot : Graphic
    {
        protected int x, y;

        public Dot(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Draw()
        {
            Console.WriteLine("Нарисовать точку в координате");
        }

        public void Move(int x, int y)
        {
            this.x += x;
            this.y += y;
            Console.WriteLine($"Сдвинули Фигуру теперь она x {this.x} y {this.y}");
        }
    }
}
