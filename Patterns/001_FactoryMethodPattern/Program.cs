using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            /* Порождающий паттерн проектирования который определяет общий интрефейс
             * Для создания объектов в суперклассе, позволяя подклассам изменять тип
             * 
             * 1) Все возвращаемые объекты должны иметь общий интерфейс
             * */
            TransportFactory factory = new TruckCreator("Зил", 1, 200);
            Console.WriteLine($"Груз загружен? {factory.DoLoading()}");

            TransportFactory factory2 = new ShipCreator("Удача", 2, 2800);
            Console.WriteLine($"Груз загружен? {factory2.DoLoading()}");
            Console.ReadLine();
        }
    }
}
