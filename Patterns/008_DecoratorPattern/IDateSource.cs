using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008_DecoratorPattern
{
    // Общий интерфейс компонентов

    public interface IDataSource
    {
        void WriteData(String data);

        String ReadData();
    }
}
