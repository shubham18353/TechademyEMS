namespace TechademyEMS.Models.Authorization_Model
{
    public class UserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
