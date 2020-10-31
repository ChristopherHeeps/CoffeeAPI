using CoffeeAPI.Model.Coffee;
using CoffeeAPI.ResourceModels.Rating;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeAPI.Logic.CoffeeAPILogic
{
    public interface ICoffeeAPILogic
    {
        bool CreateCoffee(CoffeeResourceModel coffeeRM);

        bool CreateUserRating(UserRatingResourceModel userRatingRM, int CoffeeId);

        List<UserRatingResourceModel> GetAllUserRatings();

        bool UpdateUserRating(UserRatingResourceModel userRatingRM);

        bool DeleteCoffee(int id);

        List<CoffeeResourceModel> GetCoffeeList();

        CoffeeResourceModel GetCoffeeDetails(int id);

    }
}
