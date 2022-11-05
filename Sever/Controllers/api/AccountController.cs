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
    public class AccountController : ControllerBase
    { 
        private AccountService accountService { get; set; }
        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }
        //[Authorize(Roles = "Admin,Guest")]
        
        [HttpPost("log-in")]
        public async Task<ActionResult> login(Account account)
        {
            try
            {
                Account account1 = accountService.Login(account.SDT,account.Password);
                if (account1== null)
                {
                    return Ok(new { status = false, data = "" });
                }
                return Ok(new { status = true, data = account1 });
            }
            catch (Exception)
            {
                throw;
            }

        }
        [Authorize (Roles = "Guest")]
        [HttpPost("update-data")]
        public async Task<ActionResult> UpdateAccount(Account Input) {
            try
            {
                if(accountService.UpdateAccount(Input).Equals("Done"))
                    return Ok(new { status = true, message = "Done" });
                else
                    return Ok(new { status = false, message = "Done" });

            }
            catch (Exception)
            {
                throw;
            }
           
        }
        [HttpPost("insert-Account")]
        public async Task<ActionResult> InsertAccount(AccountInsertModel Input)
        {
            try
            {
                Account newAccount = new Account();
                newAccount.SDT = Input.SDT;
                newAccount.Password = Input.Password;
                newAccount.Avatar = Input.Avatar;
                newAccount.Address = Input.Address;
                newAccount.Name = Input.Name;
                accountService.InsertAccount(newAccount);
                return Ok(new { status = true, message = "Done" });
            }
            catch (Exception e )
            {
                return Ok(new { status = false, message = e.Message });
                throw;
            }
        }

    }
}
