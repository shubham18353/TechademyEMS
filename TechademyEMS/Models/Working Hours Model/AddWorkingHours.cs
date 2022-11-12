using System.Diagnostics.CodeAnalysis;

namespace TechademyEMS.Models.Working_Hours_Model
{
    public class AddWorkingHours
    {
        [NotNull]
        public int EmpId { get; set; }
        [NotNull]
        public int MonthlyWorkingHours { get; set; }
        [NotNull]
        public int EmployeeWorkingHours { get; set; }
    }
}
