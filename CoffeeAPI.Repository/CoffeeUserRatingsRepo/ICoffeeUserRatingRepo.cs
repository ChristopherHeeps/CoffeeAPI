using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeAPI.Repository.CoffeeUserRatingsRepo
{
    public interface ICoffeeUserRatingRepo
    {

        void CreateCoffeeUserRating(int coffeeId, int userRatingId);

        List<int> GetUserRatingsForCoffee(int id);

        void DeleteUserRatingsForCoffee(int coffeId);
    }
}
