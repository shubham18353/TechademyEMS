using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TechademyEMS.Models.EmployeeModel;

namespace TechademyEMS.Models.DesignationModel
{
    public class Designation
    {
        [NotNull]
        [Key]
        public int DesigId { get; set; }
        [NotNull]
        public string DesignationName { get; set; } = "Engineer";
        [NotNull]
        public string Department { get; set; } = "Tech";
        [NotNull]
        public string Role { get; set; }

       
    }
}
