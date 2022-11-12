using System.Diagnostics.CodeAnalysis;
using TechademyEMS.Models.EmployeeModel;

namespace TechademyEMS.Models.LeaveRequest_Model
{
    public class AddLeaveRequest
    {
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
