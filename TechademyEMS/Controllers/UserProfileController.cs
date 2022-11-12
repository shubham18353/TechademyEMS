//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechademyEMS.Models.Authorization;

namespace TechademyEMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<Register> userManager;
        public UserProfileController(UserManager<Register> userManager)
        {
            this.userManager = userManager; 
        }

        [HttpGet]
       
        public async Task<Object> GetProfile()
        {
            string userId=User.Claims.First(x=>x.Type=="UserId").Value;
            var user = await userManager.FindByNameAsync(userId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };
        }
    }
}
