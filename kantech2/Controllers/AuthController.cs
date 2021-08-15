using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace kantech2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        static Random r = new Random();

        [HttpPost("token")]
        public ActionResult GetToken([FromBody] UserDetails userDetails)
        {
            // authentication
            if (userDetails.UserName != userDetails.Password)
            {
                return Unauthorized("user name must be identical to password");
            }

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(Startup.SECURITY_KEY));

            SigningCredentials signingCredentials = new SigningCredentials
                (symmetricSecurityKey,
                SecurityAlgorithms.HmacSha256Signature);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, userDetails.Role));
            claims.Add(new Claim("username", userDetails.UserName));
            claims.Add(new Claim("Id", (r.Next(100) + 1).ToString()));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "smesk.in",
                audience: "readers",
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: signingCredentials,
                claims: claims);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
