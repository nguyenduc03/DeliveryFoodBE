using Server.Models;
using Lib.Entity;
using Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingController : ControllerBase
    {
        private ToppingService ToppingService { get; set; }
        public ToppingController(ToppingService ToppingService)
        {
            this.ToppingService = ToppingService;
        }
        //[Authorize(Roles = "Admin,Guest")]
        [HttpPost("get-Topping-list")]
        public async Task<ActionResult> GetToppingList(Food food) {
            try
            {
                List<Topping> list = ToppingService.GetToppingList(food.ID_Category);
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


        [HttpPost("insert-Topping")]
        public async Task<ActionResult> InsertTopping(ToppingInsertModel toppingInput) {
            try
            {
                Topping newTopping = new Topping();
                newTopping.ID_Category = toppingInput.ID_Category;
                newTopping.Price = toppingInput.Price;
                newTopping.Name_Topping = toppingInput.Name_Topping;
                newTopping.IMG = toppingInput.IMG;
                return Ok(new { status = true, message = ToppingService.InsertTopping(newTopping)});
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        [HttpPost("update-Topping")]
        public async Task<ActionResult> UpdateFood(Topping topping)
        {
            try
            {
                return Ok(new { status = true, message = ToppingService.UpdateTopping(topping) });
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
