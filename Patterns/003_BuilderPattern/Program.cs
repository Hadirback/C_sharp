using _003_BuilderPattern.Builder;
using _003_BuilderPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_BuilderPattern
{
    class Program
    {
        /*
         Применимость
            Если есть большой конструктор с десятью опциональными параметрами.
            Когда ваш код должен создавать разные представления объекта.
            Когда нужно собирать сложные составные объекты
         */
        static void Main(string[] args)
        {
            Director d = new Director();
            Console.WriteLine(GetCar(d).ToString());
            Console.WriteLine(GatCarManual(d).ToString());
            Console.ReadLine();
        }

        private static Car GetCar(Director director)
        {
            CarBuilder carBuilder = new CarBuilder();
            director.ConstructCar(carBuilder);
            return carBuilder.GetResult();
        }

        private static CarManual GatCarManual(Director director)
        {
            CarManualBuilder carManulalBuilder = new CarManualBuilder();
            director.ConstructCar(carManulalBuilder);
            return carManulalBuilder.GetResult();
        }
    }
}
