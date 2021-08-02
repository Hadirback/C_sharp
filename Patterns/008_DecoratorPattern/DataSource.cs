using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008_DecoratorPattern
{
    public abstract class DataSource : IDataSource
    {
        public abstract string ReadData();


        public abstract void WriteData(string data);
    }
}
