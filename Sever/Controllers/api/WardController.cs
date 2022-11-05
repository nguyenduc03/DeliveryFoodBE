using Lib.Entity;
using Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sever.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : Controller
    {
        private WardService WardService { get; set; }
        public WardController(WardService WardService)
        {
            this.WardService = WardService;
        }
        [Authorize(Roles = "Guest")]

        [HttpGet("get-Ward")]
        public async Task<ActionResult> GetWard(DistrictModel district)
        {
            try
            {
                List<Ward> list = WardService.GetWardList(district.Id_District);
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
