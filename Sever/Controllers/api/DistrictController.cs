using Lib.Entity;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sever.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : Controller
    {
        private DistrictService districtService { get; set; }
        public DistrictController(DistrictService districtService)
        {
            this.districtService = districtService;
        }

        [HttpGet("get-district")]
        public async Task<ActionResult> GetDistrict(ProvinceModel province)
        {
            try
            {
                List<District> list = districtService.GetDistrictList(province.Id_Province);
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
