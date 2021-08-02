using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008_DecoratorPattern
{
    class Program
    {
        /*
         Приминимость
            Когда вам нужно добавлять обязанности объекта на лету незаметно для кода
            который их использует

            Когда нельзя расширить обязанности объекта с помощью наследования
         */
        static void Main(string[] args)
        {
            TestDecorator();
            Console.ReadLine();
        }

        private static void TestDecorator()
        {
            IDataSource dataSource = new FileDataSource("somedata.dat");
            // Чистые данные
            dataSource.WriteData("SalaryRecords");

            dataSource = new CompressionDecorator(dataSource, "Extra data super important");

            // Записываются сжатые данные
            dataSource.WriteData("SalaryRecords");

            //Console.WriteLine((dataSource as CompressionDecorator).GetExtra());

            dataSource = new EncryptionDecorator(dataSource);
            // Зашифровани данные
            dataSource.WriteData("SalaryRecords");

            dataSource = new CompressionDecorator(dataSource, "Extra data super important");

            // Записываются сжатые данные
            dataSource.WriteData("SalaryRecords");

        }
    }
}
