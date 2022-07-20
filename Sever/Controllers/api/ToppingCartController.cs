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
    public class ToppingCartController : ControllerBase
    {
        private ToppingCartService ToppingCartService { get; set; }
        public ToppingCartController(ToppingCartService ToppingCartService)
        {
            this.ToppingCartService = ToppingCartService;
        }
        //[Authorize(Roles = "Admin,Guest")]
        [HttpGet("get-Topping-Cart-list")]
        public async Task<ActionResult> GetToppingList(String  SDT) {
            try
            {
                List<ToppingDetailCart> list = ToppingCartService.GetToppingList(SDT);
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
        [HttpPost("insert-toppingDetails")]
        public async Task<ActionResult> InsertToppingCart(List<ToppingCartInsertModel> toppingDetailCarts)
        {
            try
            {
                foreach (var Input in toppingDetailCarts)
                {
                    ToppingDetailCart newCart = new ToppingDetailCart();
                    newCart.ID_Food = Input.ID_Food;
                    newCart.ID_Topping = Input.ID_Topping;
                    newCart.SDT = Input.SDT;
                    ToppingCartService.InsertToppingCart(newCart);
                }
                return Ok(new { status = true, message = "Done"});


            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost("update-Topping")]
        public async Task<ActionResult> UpdateFood(ToppingDetailCart topping)
        {
            try
            {
                return Ok(new { status = true, message = ToppingCartService.UpdateToppingCart(topping) });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("Delete-Topping")]
        public async Task<ActionResult> DeleteTopping(ToppingDetailCart topping)
        {
            try
            {
                return Ok(new { status = true, message = ToppingCartService.DeleteToppingCart(topping) });
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
