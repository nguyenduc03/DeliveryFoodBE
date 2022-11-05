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
    public class InvoiceController : ControllerBase
    {
        private InvoiceService invoiceService { get; set; }
        public InvoiceController(InvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }
        //[Authorize(Roles = "Admin,Guest")]
        [Authorize(Roles = "Guest")]

        [HttpPost("get-List-Invoice")]
        public async Task<ActionResult> GetListInvoice(Account account) {
            try
            {
                List<Invoice> list = invoiceService.GetInvoiceList(account.SDT);
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
        [Authorize(Roles = "Guest")]

        [HttpPost("insert-Invoice")]
        public async Task<ActionResult> InsertInvoice(InvoiceInsertModel Input) {
            try
            {
                Invoice newInvoice = new Invoice();
                newInvoice.Total_Money =Input.Total_Money;
                newInvoice.ID_Discount = Input.ID_Discount;
                newInvoice.SDT = Input.SDT;
                newInvoice.Date_Create = DateTime.Now.ToShortDateString();
                return Ok(new { status = true, message = invoiceService.InsertInvoice(newInvoice) });
            }
            catch (Exception)
            {
                throw;
            }
           
        }

    }
}
