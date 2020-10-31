using CoffeeAPI.Model.Rating;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CoffeeAPI.Repository.Rating
{
    public class UserRatingRepo : IUserRatingRepo
    {
        private IConfiguration _configuration;

        public UserRatingRepo(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public int CreateUserRaiting(UserRating rating)
        {
            var userRatingId = 0;

            using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString(SQLNames.ConnectionString)))
            {
                conn.Open();

                var command = new SqlCommand(SQLNames.Proc_UserRating_Create, conn) { CommandType = System.Data.CommandType.StoredProcedure };

                command.Parameters.Add(new SqlParameter("@" + SQLNames.Proc_UserRating_Param_Comment, rating.Comment));
                command.Parameters.Add(new SqlParameter("@" + SQLNames.Proc_UserRating_Param_RatingValue, rating.RatingValue));

                command.ExecuteNonQuery();

                command = new SqlCommand(string.Format("SELECT TOP 1 {0} FROM {1}",
                    SQLNames.Proc_UserRating_Param_UserRatingId,
                    SQLNames.UserRating_Table), conn) { CommandType = System.Data.CommandType.Text };

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    userRatingId = reader.GetInt32(0);
                }                
            }

            return userRatingId;
        }

        public UserRating GetUserRating(int id)
        {
            UserRating userRating = new UserRating();

            using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString(SQLNames.ConnectionString)))
            {
                conn.Open();

                var command = new SqlCommand(SQLNames.Proc_UserRating_GetUserRating, conn) { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter("@" + SQLNames.Proc_UserRating_Param_UserRatingId, id));

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    userRating = this.GetUserRatingFromSQLReader(reader);
                }
            }

            return userRating;
        }

        public List<UserRating> GetAllUserRatings()
        {
            List<UserRating> userRatings = new List<UserRating>();

            using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString(SQLNames.ConnectionString)))
            {
                conn.Open();

                var command = new SqlCommand(SQLNames.Proc_UserRating_GetAllUserRating, conn) { CommandType = System.Data.CommandType.StoredProcedure };

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    userRatings.Add(this.GetUserRatingFromSQLReader(reader));
                }
            }

            return userRatings;
        }

        public void UpdateUserRating(UserRating rating)
        {
            using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString(SQLNames.ConnectionString)))
            {
                conn.Open();

                var command = new SqlCommand(SQLNames.Proc_UserRating_Update, conn) { CommandType = System.Data.CommandType.StoredProcedure };

                command.Parameters.Add(new SqlParameter("@" + SQLNames.Proc_UserRating_Param_UserRatingId, rating.Id));
                command.Parameters.Add(new SqlParameter("@" + SQLNames.Proc_UserRating_Param_Comment, rating.Comment));
                command.Parameters.Add(new SqlParameter("@" + SQLNames.Proc_UserRating_Param_RatingValue, rating.RatingValue));

                command.ExecuteNonQuery();
            }
        }

        public void DeleteUserRating(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString(SQLNames.ConnectionString)))
            {
                conn.Open();

                var command = new SqlCommand(SQLNames.Proc_UserRating_Delete, conn) { CommandType = System.Data.CommandType.StoredProcedure };

                command.Parameters.Add(new SqlParameter("@" + SQLNames.Proc_UserRating_Param_UserRatingId, id));

                command.ExecuteNonQuery();
            }
        }

        private UserRating GetUserRatingFromSQLReader(SqlDataReader reader)
        {
            return new UserRating()
            {
                Id = reader.GetInt32(0),
                RatingValue = reader.GetInt32(1),
                Comment = reader.GetString(2)
            };
        }

        
    }
}
