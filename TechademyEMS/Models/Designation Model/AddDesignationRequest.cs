using System.Diagnostics.CodeAnalysis;
using TechademyEMS.Models.EmployeeModel;

namespace TechademyEMS.Models.Designation_Model
{
    public class AddDesignationRequest
    {
        [NotNull]
        public string DesignationName { get; set; } = "Engineer";
        [NotNull]
        public string Department { get; set; } = "Tech";
        [NotNull]
        public string Role { get; set; }

      
    }
}
