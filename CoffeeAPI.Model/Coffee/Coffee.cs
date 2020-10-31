using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeAPI.Model.Coffee
{
    [Serializable]
    public class Coffee
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
