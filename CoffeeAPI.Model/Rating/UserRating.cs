using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeAPI.Model.Rating
{
    public class UserRating
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public int RatingValue { get; set; }
    }
}
