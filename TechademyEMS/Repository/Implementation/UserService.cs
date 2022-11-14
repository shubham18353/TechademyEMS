using System.Security.Claims;
using TechademyEMS.Repository.Interface;

namespace TechademyEMS.Repository.Implementation
{
    public class UserService:IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetMyName()
        {
            try
            {
                var result = string.Empty;
                if (_httpContextAccessor.HttpContext != null)
                {
                    result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
                }
                return result;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
