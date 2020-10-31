using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeAPI.Repository
{
    public class SQLNames
    {
        public const string ConnectionString = "CoffeeDB";


        public const string Proc_Coffee_Create = "Coffee_Create";        

        public const string Proc_Coffee_GetList = "Coffee_GetList";

        public const string Proc_Coffee_Delete = "Coffee_Delete";        

        public const string Proc_Coffee_Get = "Coffee_Get";

        public const string Proc_Coffee_Param_Name = "Name";

        public const string Proc_Coffee_Param_Id = "id";

        //UserRatings
        public const string UserRating_Table = "UserRating";

        public const string Proc_UserRating_Create = "UserRating_Create";

        public const string Proc_UserRating_GetUserRating = "UserRating_GetUserRating";

        public const string Proc_UserRating_GetAllUserRating = "UserRating_GetAllUserRatings";

        public const string Proc_UserRating_Update = "UserRating_Update";

        public const string Proc_UserRating_Delete = "UserRating_Delete";

        public const string Proc_UserRating_Param_UserRatingId = "Id";

        public const string Proc_UserRating_Param_Comment = "Comment";

        public const string Proc_UserRating_Param_RatingValue = "RatingValue";


        //CoffeeUserRating

        public const string Proc_CoffeeUserRating_GetAllUserRatingsForCoffee = "CoffeeUserRating_GetAllUserRatingsForCoffee";

        public const string Proc_CoffeeUserRating_Create = "CoffeeUserRating_Create";

        public const string Proc_CoffeeUserRating_Delete = "CoffeeUserRating_Delete";

        public const string Proc_CoffeeUserRating_Param_Id = "Id";

        public const string Proc_CoffeeUserRating_Param_CoffeeId = "CoffeeId";

        public const string Proc_CoffeeUserRating_Param_UserRatingId = "UserRatingId";

    }
}
