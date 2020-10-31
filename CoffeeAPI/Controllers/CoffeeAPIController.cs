using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeAPI.Logic.CoffeeAPILogic;
using CoffeeAPI.Model.Coffee;
using CoffeeAPI.ResourceModels.Rating;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoffeeAPI.Controllers
{
    //[ApiController]
    [Route("/[controller]")]
    public class CoffeeAPIController : ControllerBase
    {
        private ICoffeeAPILogic _logic;

        public CoffeeAPIController(ICoffeeAPILogic logic)
        {
            this._logic = logic;
        }

        [HttpPost]
        [Route("CreateCoffee")]
        public IActionResult CreateCoffee(JObject jsonResult)
        {
            var coffee = JsonConvert.DeserializeObject<CoffeeResourceModel>(jsonResult.ToString());

            var result = this._logic.CreateCoffee(coffee);

            if(!result) { return NotFound(); }

            return Ok();
        }

        [HttpPost]
        [Route("CreateUserRating")]
        public IActionResult CreateUserRating(int coffeId, JObject jsonResult)
        {
            var userRating = JsonConvert.DeserializeObject<UserRatingResourceModel>(jsonResult.ToString());

            var result = this._logic.CreateUserRating(userRating, coffeId);

            if (!result) { return NotFound(); }

            return Ok();
        }

        [HttpPost]
        [Route("UpdateUserRating")]
        public IActionResult UpdateUserRating(JObject jsonResult)
        {
            var userRating = JsonConvert.DeserializeObject<UserRatingResourceModel>(jsonResult.ToString());

            var result = this._logic.UpdateUserRating(userRating);

            if (!result) { return NotFound(); }

            return Ok();
        }

        [HttpPost]
        [Route("DeleteCoffee")]
        public IActionResult DeleteCoffee(int id)
        {
            var result = this._logic.DeleteCoffee(id);

            if (!result) { return NotFound(); }

            return Ok();
        }

        [HttpGet]
        [Route("GetCoffeeUserRatings")]
        public IActionResult GetCoffeeUserRatings(int id)
        {
            return Ok(this._logic.GetCoffeeDetails(id));
        }

        [HttpGet]
        [Route("GetAllUserRatings")]
        public IActionResult GetAllUserRatings()
        {
            return Ok(this._logic.GetAllUserRatings());
        }

        [HttpGet]
        [Route("GetCoffeeList")]
        public IActionResult GetCoffeeList()
        {
            return Ok(this._logic.GetCoffeeList());
         }
    }
}