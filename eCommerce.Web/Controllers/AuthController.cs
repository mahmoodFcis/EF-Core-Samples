
using eCommerce.Web.Areas.Identity.Data;
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

namespace eCommerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly SignInManager<eCommerceWebUser> _signInManager;
        private readonly UserManager<eCommerceWebUser> _userManager;
        public AuthController(IConfiguration config, SignInManager<eCommerceWebUser> signInManager, UserManager<eCommerceWebUser> userManager)
        {
            _userManager = userManager;
            _config = config;
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Login( [FromBody] LoginViewModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginModel.EmailAddress, loginModel.Password, false, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                string token = await GenerateJSONWebToken(loginModel);
                return Ok(token);
               
            }
            else return Unauthorized();

        }

        private async Task<string> GenerateJSONWebToken(LoginViewModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var user = await _userManager.FindByEmailAsync(userInfo.EmailAddress);
            var claims = new List<Claim> {
   //     new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
        new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),

    };
            var roles = await _userManager.GetRolesAsync(user);

            foreach(string role in roles)
            {

                claims.Add(new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", role));
            }

            

          

            var token = new JwtSecurityToken(_config["JwtIssuerOptions:Issuer"],
                _config["JwtIssuerOptions:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
