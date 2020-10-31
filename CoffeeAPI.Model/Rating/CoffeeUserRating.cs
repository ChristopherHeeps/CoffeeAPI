using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeAPI.Model.Rating
{
    public class CoffeeUserRating
    {

        public int Id { get; set;
        }
        public int CoffeeId { get; set; }

        public int RatingId { get; set; }
    }
}
