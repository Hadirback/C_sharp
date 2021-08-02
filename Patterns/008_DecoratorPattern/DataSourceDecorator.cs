using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008_DecoratorPattern
{
    /*
     Родитель всех декораторов содержит код обёртывания
     */
    public class DataSourceDecorator : IDataSource
    {
        protected IDataSource wrappee;
        public DataSourceDecorator(IDataSource dataSource)
        {
            wrappee = dataSource;
        }

        public virtual string ReadData()
        {
            return wrappee.ReadData();
        }

        public virtual void WriteData(string data)
        {
            wrappee.WriteData(data);
        }
    }
}
