using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechademyEMS.Models.Authorization;
using TechademyEMS.Models.Authorization_Model;

namespace TechademyEMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<Register> userManager;
        private SignInManager<Register> signInManager;

        public ApplicationUserController(UserManager<Register> userManager, SignInManager<Register> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<Object> PostApplicationUser(RegisterModel register)
        {
            try { 
            Register applicationUser = new Register()
            {
                UserName = register.UserName,
                Email = register.Email,
                EmployeeId = register.EmployeeId,
                FullName=register.FullName
            };
            
            
                var user = await userManager.CreateAsync(applicationUser,register.Password);
                return Ok(user);
            }
            catch
            {
                throw ;
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                var user = await userManager.FindByNameAsync(login.Username);
                if (user != null && await userManager.CheckPasswordAsync(user, login.Password))
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim("UserId", user.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my top secret key")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return Ok(new { token });
                }
                else
                {
                    return BadRequest(new { Message = "UserName or Password Incorrect!" });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
    }
}
