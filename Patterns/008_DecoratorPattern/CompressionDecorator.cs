using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008_DecoratorPattern
{
    public class CompressionDecorator : DataSourceDecorator
    {
        public String ExtraMaterials { get; set; }
        public CompressionDecorator(IDataSource dataSource, String extra)
            : base(dataSource)
        {
            ExtraMaterials = extra;
        }

        public override string ReadData()
        {
            Console.WriteLine("Распаковываем данные");
            return wrappee.ReadData();
        }

        public override void WriteData(string data)
        {
            Console.WriteLine("Запаковываем данные");
            wrappee.WriteData(data);
        }

        public string GetExtra()
        {
            return ExtraMaterials + " !!!! ";
        }
    }
}
