using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectManinulationTest
{
    public class DoublePispatchTest
    {
        public static void Run()
        {
            RunExport(new Circle());
        }
        public static void RunExport(IGraphic graphic)
        {
            Exporter ex = new Exporter();
            ex.Export(graphic);
        }
    }

    public class Exporter
    {
        /*public void Export(IGraphic shape)
        {
            switch (shape)
            {
                case Shape s:
                    Console.WriteLine("Exporting shape");
                    break;
                case Dot d:
                    Console.WriteLine("Exporting dot");
                    break;
                case Circle c:
                    Console.WriteLine("Exporting Circle");
                    break;
                case Rectangle r:
                    Console.WriteLine("Exporting Rectangle");
                    break;
                default:
                    break;
            }
        }*/
        public void Export(IGraphic shape)
        {
            Console.WriteLine("Exporting IGraphic");
        }

        public void Export(Shape shape)
        {
            Console.WriteLine("Exporting shape");
        }

        public void Export(Dot shape)
        {
            Console.WriteLine("Exporting Dot");
        }

        public void Export(Circle shape)
        {
            Console.WriteLine("Exporting Circle");
        }

        public void Export(Rectangle shape)
        {
            Console.WriteLine("Exporting Rectangle");
        }
    }

    public interface IGraphic
    {
        void Draw();
    }

    public class Shape : IGraphic
    {
        public int Id { get; set; }

        public void Draw()
        {
            Console.WriteLine("Shape Draw");
        }
    }

    public class Dot : IGraphic
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Draw()
        {
            Console.WriteLine("Dot Draw");
        }
    }

    public class Circle : IGraphic
    {
        public int Radius { get; set; }

        public void Draw()
        {
            Console.WriteLine("Circle  Draw");
        }
    }

    public class Rectangle : IGraphic
    {
        public int Width { get; set; }
        public int Height { get; set; }


        public void Draw()
        {
            Console.WriteLine("Rectangle  Draw");
        }
    }
}
