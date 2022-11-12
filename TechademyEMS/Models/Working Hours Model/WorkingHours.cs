using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TechademyEMS.Models.WorkingHoursModel
{
    public class WorkingHours
    {
        [NotNull]
        [Key]
        public int Id { get; set; }
        [NotNull]
        public int EmpId { get; set; }
        [Required, NotNull]
        public int MonthlyWorkingHours { get; set; }
        [NotNull]
        public int EmployeeWorkingHours { get; set; }


    }
}
