using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008_DecoratorPattern
{
    public class EncryptionDecorator : DataSourceDecorator
    {
        public EncryptionDecorator(IDataSource dataSource)
            : base(dataSource)
        {

        }

        public override string ReadData()
        {
            Console.WriteLine("Расшифровываем данные");
            return wrappee.ReadData();
        }

        public override void WriteData(string data)
        {
            Console.WriteLine("Зашифровываем данные");
            wrappee.WriteData(data);
        }
    }
}
