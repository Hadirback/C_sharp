using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008_DecoratorPattern
{
    /*
     Один из конкретных компонентов реализует базовую функциональность
     */
    public class FileDataSource : DataSource
    {
        private String filename;

        public FileDataSource(String filename)
        {
            this.filename = filename;
        }

        public override string ReadData()
        {
            Console.WriteLine("Что то прочитали и вернули");
            return "SUPERDATA";
        }

        public override void WriteData(string data)
        {
            Console.WriteLine("Что то записали!");
        }
    }
}
