using CoffeeAPI.Model.Coffee;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeAPI.Repository.CoffeeRepo
{
    public interface ICoffeeRepo
    {
        void CreateCoffee(Coffee coffee);

        Coffee GetCoffee(int id);

        List<Coffee> GetCoffeeList();

        void DeleteCoffee(int id);
    }
}
