using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TechademyEMS.Models.EmployeeModel;

namespace TechademyEMS.Models.LeaveRequestModel
{
    public class LeaveRequest
    {
        [NotNull, Key]
        public int LeaveId { get; set; }
        [NotNull]
        public string LeaveType { get; set; }
        [NotNull]
        public string Reason { get; set; }
        [NotNull]
        public string Status { get; set; } 
        [NotNull]
        public DateTime FromDate { get; set; }
        [NotNull]
        public DateTime ToDate { get; set; }
        
    }
}
