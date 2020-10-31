using System;
using System.Collections.Generic;
using System.Text;
using CoffeeAPI.Model.Rating;

namespace CoffeeAPI.Repository.Rating
{
    public interface IUserRatingRepo
    {
        int CreateUserRaiting(UserRating rating);

        List<UserRating> GetAllUserRatings();

        UserRating GetUserRating(int id);

        void DeleteUserRating(int id);

        void UpdateUserRating(UserRating rating);
    }
}
