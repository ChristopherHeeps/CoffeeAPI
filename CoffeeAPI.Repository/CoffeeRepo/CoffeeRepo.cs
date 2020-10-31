using CoffeeAPI.Model;
using CoffeeAPI.Model.Coffee;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CoffeeAPI.Repository.CoffeeRepo
{
    public class CoffeeRepo : ICoffeeRepo
    {
        private IConfiguration _configuration;

        public CoffeeRepo(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public void CreateCoffee(Coffee coffe)
        {
            using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString(SQLNames.ConnectionString)))
            {
                conn.Open();

                var command = new SqlCommand(SQLNames.Proc_Coffee_Create, conn) { CommandType = System.Data.CommandType.StoredProcedure };

                command.Parameters.Add(new SqlParameter("@" + SQLNames.Proc_Coffee_Param_Name, coffe.Name));

                command.ExecuteNonQuery();

            }
        }

        public void DeleteCoffee(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString(SQLNames.ConnectionString)))
            {
                conn.Open();

                var command = new SqlCommand(SQLNames.Proc_Coffee_Delete, conn) { CommandType = System.Data.CommandType.StoredProcedure };

                command.Parameters.Add(new SqlParameter("@" + SQLNames.Proc_Coffee_Param_Id, id));

                command.ExecuteNonQuery();
            }
        }

        public Coffee GetCoffee(int id)
        {

            Coffee coffee = new Coffee();
            using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString(SQLNames.ConnectionString)))
            {
                conn.Open();

                var command = new SqlCommand(SQLNames.Proc_Coffee_Get, conn) { CommandType = System.Data.CommandType.StoredProcedure };

                command.Parameters.Add(new SqlParameter("@" + SQLNames.Proc_Coffee_Param_Id, id));

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    coffee = this.GetCoffeeFromSQLReader(reader);
                }
            }

            return coffee;
        }

        public List<Coffee> GetCoffeeList()
        {
            List<Coffee> coffees = new List<Coffee>();

            using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString(SQLNames.ConnectionString)))
            {
                conn.Open();

                var command = new SqlCommand(SQLNames.Proc_Coffee_GetList, conn) { CommandType = System.Data.CommandType.StoredProcedure };

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    coffees.Add(this.GetCoffeeFromSQLReader(reader));
                }
            }

            return coffees;
        }

        private Coffee GetCoffeeFromSQLReader(SqlDataReader reader)
        {
            return new Coffee()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            };
        }
    }
}
