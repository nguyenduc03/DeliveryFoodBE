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
using System.Net.Http;

namespace Server.Controllers.api
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private ProvinceService provinceService { get; set; }
        public ProvinceController(ProvinceService provinceService)
        {
            this.provinceService = provinceService;
        }
        //[Authorize(Roles = "Admin,Guest")]
        [HttpGet("get-all-province")]
        public async Task<ActionResult> GetAllProvince() {
            try
            {
                List<Province> list = provinceService.GetProvinceList();
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
