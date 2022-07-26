﻿using Server.Models;
using Lib.Entity;
using Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace Server.Controllers.api
{   
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private FoodService foodService { get; set; }
        public FoodController(FoodService foodService)
        {
            this.foodService = foodService;
        }
        //[Authorize(Roles = "Admin,Guest")]
        [HttpGet("get-all-food-list")]
        public async Task<ActionResult> GetAllFoodList() {
            try
            {
                List<Food> list = foodService.GetFoodList();
                if (list.Count == 0)
                {
                    return Ok(new { status = false, data = "Null" });
                }
                return Ok(new { status = true, data = list });
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        [HttpPost("get-foods")]
        public async Task<ActionResult> GetFoodCart(List<Food> inputFoods)
        {
            try
            {
                List<Food> list = foodService.GetFoodList(inputFoods);
                if (list.Count == 0)
                {
                    return Ok(new { status = false, data = "Null" });
                }
                return Ok(new { status = true, data = list });
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost("get-food-byID")]
        public async Task<ActionResult> GetFoodByID(Food inputFood)
        {
            try
            {
                Food food = foodService.GetFoodByID(inputFood.ID_Food);
                if (food.ID_Category== null )
                {
                    return Ok(new { status = false, data = "Null" });
                }
                return Ok(new { status = true, data = food });
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost("get-food-byName")]
        public async Task<ActionResult> GetFoodByName(Food input)
        {

            try
            {
                List<Food> food = foodService.GetFoodByName(input.Name_Food);
                if (food.Count==0)
                {
                    return Ok(new { status = false, data = "Null" });
                }
                return Ok(new { status = true, data = food });
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpGet("get-Recent-food")]
        public async Task<ActionResult> GetRecentfood()
        {
            try
            {                List<Food> list = foodService.GetRecentFood();

                if (list.Count == 0)
                {
                    return Ok(new { status = false, data = "Null" });
                }
                return Ok(new { status = true, data = list });
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost("get-food-in-Category")]
        public async Task<ActionResult> GetfoodCategory(Category category)
        {
            try
            {
                
                List<Food> list = foodService.GetFoodByCategory(category.ID_Category);
                if (list.Count == 0)
                {

                    return Ok(new { status = false, data = "Null" });
                }
                return Ok(new { status = true, data = list });
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost("insert-food")]
        public async Task<ActionResult> InsertFood(FoodInsertModel foodInput) {
            try
            {
                Food newFood = new Food();
                newFood.DateAdd = DateTime.Now.ToShortDateString();
                newFood.ID_Category = foodInput.ID_Category;
                newFood.Name_Food = foodInput.Name_Food;
                newFood.Price   = foodInput.Price;
                newFood.Description = foodInput.Description;
                newFood.Picture = foodInput.Picture;
                return Ok(new { status = true, message = foodService.InsertFood(newFood)});
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        [HttpPost("update-food")]
        public async Task<ActionResult> UpdateFood(Food foodInput)
        {
            try
            {
                return Ok(new { status = true, message = foodService.UpdateFood(foodInput) });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("Get-more-food")]
        public async Task<ActionResult> GetMoreFood(Food foodInput)
        {
            try
            {
                int temp = 0;
                if(foodInput.ID_Food !=-1)
                   temp= foodInput.ID_Food;
                List<Food> foodList = foodService.GetMoreFood(temp);
                if (foodList.Count > 0)
                    return Ok(new { status = true, data = foodList });
                else
                    return Ok(new { status = false, data = "Null" });

            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet("get-popular-food-list")]
        public async Task<ActionResult> GetPopularfoodList()
        {
            try
            {
                List<Food> list = foodService.GetPopularFoodList();
                if (list.Count == 0)
                {
                    return Ok(new { status = false, data = "Null" });
                }
                return Ok(new { status = true, data = list });
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpGet("get-list-food-discount")]
        public async Task<ActionResult> GetFoodDiscount()
        {
            try
            {
                List<List<Food>> list = foodService.GetFoodDiscount();
                if (list.Count == 0)
                {
                    return Ok(new { status = false, data = "Null" });
                }
                return Ok(new { status = true, data = list });
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet("get-top-food")]
        public async Task<ActionResult> GetTopFood()
        {
            try
            {
                List<Food> list = foodService.GetTopFood();
                if (list.Count == 0)
                {
                    return Ok(new { status = false, data = "Null" });
                }
                return Ok(new { status = true, data = list });
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet("get-top-food-discount")]
        public async Task<ActionResult> GetTopFoodDiscount()
        {
            try
            {
                List<Food> list = foodService.GetTopFoodDiscount();
                if (list.Count == 0)
                {
                    return Ok(new { status = false, data = "Null" });
                }
                return Ok(new { status = true, data = list });
            }
            catch (Exception)
            {

                throw;
            }

        }





    }
}
