using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_SingletonPattern
{
    public class DatabaseSingleton
    {
        private static DatabaseSingleton instance;
        private static readonly object locker = new object();
        public String Value { get; set; }
        private DatabaseSingleton()
        {
            // Подключение к БД
        }

        public static DatabaseSingleton GetInstance(String strValue)
        {
            if(instance == null)
            {
                lock (locker)
                {
                    if(instance == null)
                    {
                        instance = new DatabaseSingleton();
                        instance.Value = strValue;
                    }
                }
            }

            return instance;
        }
    }
}
