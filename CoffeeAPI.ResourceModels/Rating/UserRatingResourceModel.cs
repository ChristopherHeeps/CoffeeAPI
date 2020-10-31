using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeAPI.ResourceModels.Rating
{
    public class UserRatingResourceModel
    {
        public int Id { get; set; }

        public int RatingValue { get; set; }

        public string Comment { get; set; }
    }
}
