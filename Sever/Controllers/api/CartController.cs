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
    public class CartController : ControllerBase
    {
        private CartService cartService { get; set; }
        public CartController(CartService cartService)
        {
            this.cartService = cartService;
        }
        //[Authorize(Roles = "Admin,Guest")]
        [HttpGet("get-cart")]
        public async Task<ActionResult> GetCart(Account account) {
            try
            {
                List<Cart> list = cartService.GetCart(account);
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
        [HttpGet("get-QR")]
        public async Task<ActionResult> GetQR(Account account)
        {
            try
            {
                string list = cartService.GetQR(account);
                
                return Ok(new { status = true, data = list });
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost("insert-list-food")]

        // them topping 
        //, List<ToppingDetailCart> toppingDetails
        public async Task<ActionResult> InsertListFood(List<CartInsertModel> list) {
            try
            {
                foreach (var Input in list)
                {
                    Cart newCart = new Cart();
                    newCart.ID_Food = Input.ID_Food;
                    newCart.Total_Money = Input.Total_Money;
                    newCart.Quantity = Input.Quantity;
                    newCart.SDT = Input.SDT;
                    cartService.InsertCart(newCart);
                }
                return Ok(new { status = true, message ="Done"});
            }
            catch (Exception e)
            {
                return Ok(new { status = false, message =e.Message  });
                throw;
            }

        }
        
        [HttpPost("insert-food")]

        // them topping 
        //, List<ToppingDetailCart> toppingDetails
        public async Task<ActionResult> InsertFood(CartInsertModel Input)
        {
            try
            {
                    Cart newCart = new Cart();
                    newCart.ID_Food = Input.ID_Food;
                    newCart.Total_Money = Input.Total_Money;
                    newCart.Quantity = Input.Quantity;
                    newCart.SDT = Input.SDT;
                    return Ok(new { status = true, message = cartService.InsertCart(newCart) });
            }
            catch (Exception e)
            {
                return Ok(new { status = false, message = e.Message });
                throw;
            }
        }



        [HttpPost("payment")]
        public async Task<ActionResult> Payment(Account Input)
        {
            try
            {
                string result = cartService.Payment(Input);
                if (result == "Null")
                {
                    return Ok(new { status = false, message = result });
                }

                return Ok(new { status = true, message = result });
            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost("update-Cart")]
        public async Task<ActionResult> UpdateCart(List<Cart> carts)
        {
            try
            {
                foreach (var Input in carts)
                {
                    cartService.UpdateCart(Input);

                }

                return Ok(new { status = true, message = "done" });
            }
            catch (Exception e)
            {
                return Ok(new { status = false, message = e.Message });
                throw;
            }
        }

    }
}
