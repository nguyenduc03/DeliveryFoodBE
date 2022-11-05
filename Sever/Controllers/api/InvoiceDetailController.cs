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
    public class InvoiceDetailController : ControllerBase
    {
        private InvoiceDetailService invoiceDetailService { get; set; }
        public InvoiceDetailController(InvoiceDetailService invoiceDetailService)
        {
            this.invoiceDetailService = invoiceDetailService;
        }
        //[Authorize(Roles = "Admin,Guest")]
        [Authorize(Roles = "Guest")]

        [HttpPost("get-Invoice-Detail")]
        public async Task<ActionResult> GetListInvoice(Invoice invoice) {
            try
            {
                List<InvoiceDetail> list = invoiceDetailService.GetInvoiceDetail(invoice.ID_invoice);
                if (list == null)
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
