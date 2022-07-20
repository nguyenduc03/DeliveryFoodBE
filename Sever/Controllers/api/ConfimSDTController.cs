using Server.Models;
using Lib.Entity;
using Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.IdentityModel.Protocols;

namespace Server.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfimSDTController : ControllerBase
    {
        List<ConfimAccount> _accounts;
        private AccountService ConfimSDTService { get; set; }
        public ConfimSDTController()
        {
            _accounts = new List<ConfimAccount>();
            

        }

        //[Authorize(Roles = "Admin,Guest")]
        
        [HttpPost("Create_Code")]
        public async Task<ActionResult> getCode(Account input)
        {
            Random random = new Random();
            int code = random.Next(1000,9999);
            try
            {
               // string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID"); //AC5ba0439d95f0e68f7d4d24958a7b2d25
                string accountSid = "AC5ba0439d95f0e68f7d4d24958a7b2d25"; //AC5ba0439d95f0e68f7d4d24958a7b2d25
               // string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN"); //cfe1654ffa21626a189c84ece634972c
                string authToken = "cfe1654ffa21626a189c84ece634972c"; //cfe1654ffa21626a189c84ece634972c
                TwilioClient.Init(accountSid, authToken);

                string Str1 = input.SDT.Substring(1);
                var message = MessageResource.Create(
                    body: "Dưới đây là mã xác nhận của bạn. Mã code của bạn là : "+ code +" From TrisDepTrai",
                    from: new Twilio.Types.PhoneNumber("+15042267859"),//+15042267859
                    to: new Twilio.Types.PhoneNumber("+84"+Str1) // +84 835 866 056    
                );
                ConfimAccount temp = new ConfimAccount();
                temp.code = code;
                temp.account = input;
                _accounts.Add(temp);
                Console.WriteLine(message.Sid);
                return Ok(code);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
