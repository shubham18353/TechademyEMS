using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TechademyEMS.Models.DesignationModel;
using TechademyEMS.Models.LeaveRequestModel;
using TechademyEMS.Models.PaymentRulesModel;

namespace TechademyEMS.Models.Employee_Model
{
    public class AddEmployeeRequest
    {
        [NotNull]
        public string Name { get; set; }
        [NotNull, Phone]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public int Payscale { get; set; }
        
        public int LeaveId { get; set; }
        
        public string DesigId { get; set; }
        
        public string IsWorking { get; set; }
    }
}
