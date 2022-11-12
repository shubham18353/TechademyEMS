using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TechademyEMS.Models.Authorization_Model
{
    public class RegisterModel
    {
        public int EmployeeId { get; set; }
        [NotNull]
        public string UserName { get; set; }
        [NotNull, DataType(DataType.Password)]
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
