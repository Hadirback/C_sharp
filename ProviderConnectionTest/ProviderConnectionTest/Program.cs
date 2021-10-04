using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderConnectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);
            SqlConnectionStringBuilder strBuilder = new SqlConnectionStringBuilder(connectionString);

            using (DbConnection connection = factory.CreateConnection())
            {
                if(connection == null)
                {
                    ShowError("Connection");
                    return;
                }

                Console.WriteLine($"Conntction - {connection.GetType().Name}");
                connection.ConnectionString = strBuilder.ConnectionString;
                connection.Open();

                DbCommand command = factory.CreateCommand();
                if(command == null)
                {
                    ShowError("Command");
                    return;
                }

                Console.WriteLine($"Command - {command.GetType().Name}");
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Inventory";

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    Console.WriteLine($"Reader - {dataReader.GetType().Name}");
                    while (dataReader.Read())
                    {
                        Console.WriteLine($"Car {dataReader["CarId"]} is a {dataReader["Make"]}");
                    }
                }
            }
            Console.ReadKey();
        }

        private static void ShowError(String str)
        {
            Console.WriteLine($"problem {str}");
            Console.ReadLine();
        }
    }
}
