using Lib.Entity;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sever.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : Controller
    {
        private DiscountService discountService { get; set; }
        public DiscountController(DiscountService discountService)
        {
            this.discountService = discountService;
        }

        
        [HttpGet("get-discount-available")]
        public async Task<ActionResult> GetDiscountAvailable()
        {
            try
            {
                List<Discount> discounts = discountService.GetDiscountAvailable();
                if (discounts.Count==0)
                {
                    return Ok(new { status = false, data = "Null" });
                }
                return Ok(new { status = true, data = discounts });
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet("get-discount-invoice")]
        public async Task<ActionResult> GetDiscountInvoice()
        {
            try
            {
                List<Discount> discounts = discountService.GetDiscountInvoice();
                if (discounts.Count == 0)
                {
                    return Ok(new { status = false, data = "Null" });
                }
                return Ok(new { status = true, data = discounts });
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
