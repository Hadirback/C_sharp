using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _004_PrototypePattern
{
    class Program
    {
        /*
         Применимость
            Код не должен зависеть от классов копируемых объектов
            Есть много подклассов которые отличаются начальными значениями полей.
         */
        static void Main(string[] args)
        {
            /*
            String a = "a";
            String b = a;
            b = "B";
            Console.WriteLine(a);
            Console.WriteLine(b);*/


            Person p1 = new Person();
            p1.Age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.Name = "Jack Daniels";
            p1.IdInfo = new IdInfo(666);

            // Выполнить поверхностное копирование p1 и присвоить её p2.
            Person p2 = p1.ShallowCopy();
            // Сделать глубокую копию p1 и присвоить её p3.
            Person p3 = p1.DeepCopy();

            Console.WriteLine("Original values of p1, p2, p3:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values:");
            DisplayValues(p3);

            
            // Изменить значение свойств p1 и отобразить значения p1, p2 и p3.
            p1.Age = 32;
            p1.BirthDate = Convert.ToDateTime("1900-01-01");
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7878;
            Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values (reference values have changed):");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values (everything was kept the same):");
            DisplayValues(p3);

            Console.ReadLine();
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
                p.Name, p.Age, p.BirthDate);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        }
    }

    class Client
    {
        void Operation()
        {
            Prototype prototype = new ConcretePrototype1(1);
            Prototype clone = prototype.Clone();
            prototype = new ConcretePrototype2(2);
            clone = prototype.Clone();
        }
    }


    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    [Serializable]
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    [Serializable]
    class Circle : IFigure
    {
        int radius;
        public Point Point { get; set; }

        public Circle(int r, int x, int y)
        {
            radius = r;
            this.Point = new Point { X = x, Y = y };
        }

        public object DeepCopy()
        {
            object figure = null;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter binFormatter = new BinaryFormatter(null,
                    new StreamingContext(StreamingContextStates.Clone));

                binFormatter.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);

                figure = binFormatter.Deserialize(ms);
            }
            return figure;
        }

        public IFigure Clone()
        {
            return this.MemberwiseClone() as IFigure;
        }

        public void GetInfo()
        {
            Console.WriteLine("Круг радиусом {0} и центром в точке ({1}, {2})", radius, Point.X, Point.Y);
        }
    }
}
