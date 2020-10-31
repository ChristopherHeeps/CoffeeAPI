using CoffeeAPI.ResourceModels.Rating;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeAPI.Model.Coffee
{
    [Serializable]
    public class CoffeeResourceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AverageRating { get; set; }

        public List<UserRatingResourceModel> UserRatings { get; set; }
    }
}
