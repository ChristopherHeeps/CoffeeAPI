using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CoffeeAPI.Repository.CoffeeUserRatingsRepo
{
    public class CoffeeUserRatingRepo : ICoffeeUserRatingRepo
    {
        private IConfiguration _configuration;

        public CoffeeUserRatingRepo(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public void CreateCoffeeUserRating(int coffeeId, int userRatingId)
        {
            using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString(SQLNames.ConnectionString)))
            {
                conn.Open();

                var command = new SqlCommand(SQLNames.Proc_CoffeeUserRating_Create, conn) { CommandType = System.Data.CommandType.StoredProcedure };

                command.Parameters.Add(new SqlParameter("@" + SQLNames.Proc_CoffeeUserRating_Param_CoffeeId, coffeeId));
                command.Parameters.Add(new SqlParameter("@" + SQLNames.Proc_CoffeeUserRating_Param_UserRatingId, userRatingId));

                command.ExecuteNonQuery();
            }
        }

        public void DeleteUserRatingsForCoffee(int coffeeId)
        {
            using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString(SQLNames.ConnectionString)))
            {
                conn.Open();

                var command = new SqlCommand(SQLNames.Proc_CoffeeUserRating_Delete, conn) { CommandType = System.Data.CommandType.StoredProcedure };

                command.Parameters.Add(new SqlParameter("@" + SQLNames.Proc_CoffeeUserRating_Param_CoffeeId, coffeeId));

                command.ExecuteNonQuery();
            }
        }

        public List<int> GetUserRatingsForCoffee(int coffeeId)
        {
            List<int> userRatingIds = new List<int>();

            using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString(SQLNames.ConnectionString)))
            {
                conn.Open();

                var command = new SqlCommand(SQLNames.Proc_CoffeeUserRating_GetAllUserRatingsForCoffee, conn) { CommandType = System.Data.CommandType.StoredProcedure };

                SqlDataReader reader = command.ExecuteReader();

                int i = 0;

                while (reader.Read())                
                {              
                    userRatingIds.Add(reader.GetInt32(i));
                    i++;
                }
            }

            return userRatingIds;
        }
    }
}
