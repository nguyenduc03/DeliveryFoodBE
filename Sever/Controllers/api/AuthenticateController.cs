using Server.Models;
using Lib.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(TokenModel tokenModel)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (!await roleManager.RoleExistsAsync("Guest"))
                await roleManager.CreateAsync(new IdentityRole("Guest"));
            ApplicationUser userExists = new ApplicationUser()
            {
                //Email = tokenModel.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = tokenModel.UserName,
                Email = tokenModel.UserName
            };

            var result = await userManager.CreateAsync(userExists, tokenModel.Password);
            await userManager.AddToRoleAsync(userExists, "Guest");
            return Ok(new { status = "sucess", message = "" });
        }
        [HttpPost("token")]
        public async Task<ActionResult> GetToken(TokenModel tokenModel)
        {
            var user = await userManager.FindByNameAsync(tokenModel.UserName);
            var result = await userManager.CheckPasswordAsync(user, tokenModel.Password);
            if (result)
            {

                var userRoles = await userManager.GetRolesAsync(user);
                string securityKey = configuration["JWT:Secret"];
                // symmetric security key
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, tokenModel.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                // signing credentials
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
                var token = new JwtSecurityToken(
                    claims: authClaims,
                    issuer: configuration["JWT:ValidIssuer"],
                    audience: configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials
                );
                string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { status = "sucess", message = "", token = tokenStr });
            }
            return Ok(new { status = "sucess", message = "error", token = "" });
        }
    }
}
