using System.ComponentModel.DataAnnotations;

namespace TechademyEMS.Models.Authorization
{
    public class Login
    {
        
        public string Username { get; set; }
        public string Password { get; set; }
        //[Required,EmailAddress]
        //public string Email { get; set; }
    }
}
