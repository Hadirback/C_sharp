using AutoLotDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDAL.DataOperations
{
    public class InventoryDAL
    {
        private readonly string connectionString;
        public InventoryDAL() :
            this(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog=AutoLot; Integrated Security=True")
        {

        }

        public InventoryDAL(string connString)
        {
            connectionString = connString;
        }

        private SqlConnection sqlConnection = null;
        private void OpenConnection()
        {
            sqlConnection = new SqlConnection { ConnectionString = connectionString };
            sqlConnection.Open();
        }

        private void CloseConnection()
        {
            if(sqlConnection?.State != ConnectionState.Closed)
            {
                sqlConnection?.Close();
            }
        }

        public List<Car> GetAllInventory()
        {
            OpenConnection();

            List<Car> inventory = new List<Car>();

            string sql = "SELECT * FROM Inventory";
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (sqlDataReader.Read())
                {
                    inventory.Add(new Car()
                    {
                        CarId = (int)sqlDataReader["CarId"],
                        Color = (string)sqlDataReader["Color"],
                        Make = (string)sqlDataReader["Make"],
                        PetName = (string)sqlDataReader["PetName"]
                    });
                }
                sqlDataReader.Close();
            }

            return inventory;
        }

        public Car GetCar(int id)
        {
            OpenConnection();
            Car car = null;

            string sql = $"SELECT * FROM Inventory WHERE CarId = {id}";

            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (sqlDataReader.Read())
                {
                    car = new Car()
                    {
                        CarId = (int)sqlDataReader["CarId"],
                        Color = (string)sqlDataReader["Color"],
                        Make = (string)sqlDataReader["Make"],
                        PetName = (string)sqlDataReader["PetName"]
                    };
                }
                sqlDataReader.Close();
            }

            return car;
        }

        public void InsertAuto(Car car)
        {
            OpenConnection();

            string sql = $"INSERT INTO Inventory (Make, Color, PetName) " +
                $"VALUES ('@Make', '@Color', '@PetName')";

            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Make",
                        Value = car.Make,
                        SqlDbType = SqlDbType.Char,
                        Size = 10
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Color",
                        Value = car.Color,
                        SqlDbType = SqlDbType.Char,
                        Size = 10
                    },
                    new SqlParameter
                    {
                        ParameterName = "@PetName",
                        Value = car.PetName,
                        SqlDbType = SqlDbType.Char,
                        Size = 10
                    },

                };
                command.Parameters.AddRange(sqlParameters);
                command.ExecuteNonQuery();
                CloseConnection();
            }
        }
    }
}
