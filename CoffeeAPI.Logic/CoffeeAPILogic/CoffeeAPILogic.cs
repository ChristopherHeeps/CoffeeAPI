using CoffeeAPI.Model.Coffee;
using CoffeeAPI.Model.Rating;
using CoffeeAPI.Repository.CoffeeRepo;
using CoffeeAPI.Repository.CoffeeUserRatingsRepo;
using CoffeeAPI.Repository.Rating;
using CoffeeAPI.ResourceModels.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeAPI.Logic.CoffeeAPILogic
{
    public class CoffeeAPILogic : ICoffeeAPILogic
    {
        private readonly ICoffeeRepo _coffeeRepo;
        private readonly IUserRatingRepo _userRatingRepo;
        private readonly ICoffeeUserRatingRepo _coffeeUserRatingRepo;

        public CoffeeAPILogic(ICoffeeRepo coffeeRepo, IUserRatingRepo userRatingRepo, ICoffeeUserRatingRepo coffeeUserRatingRepo)
        {
            this._coffeeRepo = coffeeRepo;
            this._userRatingRepo = userRatingRepo;
            this._coffeeUserRatingRepo = coffeeUserRatingRepo;
        }

        public bool CreateUserRating(UserRatingResourceModel userRatingRM, int CoffeeId)
        {
            try
            {
                var coffee = this._coffeeRepo.GetCoffee(CoffeeId);

                var userRating = new UserRating()
                {
                    Comment = userRatingRM.Comment,
                    RatingValue = userRatingRM.RatingValue
                };

                var userRatingId = this._userRatingRepo.CreateUserRaiting(userRating);                             

                this._coffeeUserRatingRepo.CreateCoffeeUserRating(coffee.Id, userRatingId);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateCoffee(CoffeeResourceModel coffeeRM)
        {
            try
            {
                var coffee = new Coffee()
                {
                    Name = coffeeRM.Name
                };

                this._coffeeRepo.CreateCoffee(coffee);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateUserRating(UserRatingResourceModel userRatingRM)
        {
            try
            {
                var userRating = this._userRatingRepo.GetUserRating(userRatingRM.Id);

                userRating.Comment = userRatingRM.Comment;
                userRating.RatingValue = userRatingRM.RatingValue;

                this._userRatingRepo.UpdateUserRating(userRating);

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool DeleteCoffee(int id)
        {
            try
            {
                var ratingIds = this._coffeeUserRatingRepo.GetUserRatingsForCoffee(id);

                foreach(var ratingId in ratingIds)
                {
                    this._userRatingRepo.DeleteUserRating(id);
                }

                this._coffeeUserRatingRepo.DeleteUserRatingsForCoffee(id);

                this._coffeeRepo.DeleteCoffee(id);

                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }

        public CoffeeResourceModel GetCoffeeDetails(int id)
        {

            CoffeeResourceModel rm = new CoffeeResourceModel();

            var coffee = this._coffeeRepo.GetCoffee(id);

            var userRatingIds = this._coffeeUserRatingRepo.GetUserRatingsForCoffee(id);

            foreach(var userRatingsId in userRatingIds)
            {
                var userRating = this._userRatingRepo.GetUserRating(userRatingsId);

                rm.UserRatings.Add(new ResourceModels.Rating.UserRatingResourceModel()
                {
                    Id= userRating.Id,
                    Comment = userRating.Comment,
                    RatingValue = userRating.RatingValue
                });
            }

            rm.AverageRating = rm.UserRatings.Sum(x => x.RatingValue) / rm.UserRatings.Count;

            return rm;
        }

        public List<UserRatingResourceModel> GetAllUserRatings()
        {
            List<UserRatingResourceModel> results = new List<UserRatingResourceModel>();

            var ratings = this._userRatingRepo.GetAllUserRatings();

            foreach(var rating in ratings)
            {
                results.Add(new UserRatingResourceModel()
                {
                    Id = rating.Id,
                    Comment = rating.Comment,
                    RatingValue = rating.RatingValue
                });
            }

            return results;
        }

        public List<CoffeeResourceModel> GetCoffeeList()
        {
            var results = new List<CoffeeResourceModel>();

            var coffees =  this._coffeeRepo.GetCoffeeList();

            foreach(var coffee in coffees)
            {
                results.Add(new CoffeeResourceModel()
                {
                    Id = coffee.Id,
                    Name = coffee.Name
                });
            }

            return results;
        }

    }
}
