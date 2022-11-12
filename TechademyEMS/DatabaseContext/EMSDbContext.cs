using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechademyEMS.Models;
using TechademyEMS.Models.Authorization;
using TechademyEMS.Models.Authorization_Model;
using TechademyEMS.Models.DesignationModel;
using TechademyEMS.Models.EmployeeModel;
using TechademyEMS.Models.LeaveRequestModel;
using TechademyEMS.Models.PaymentRulesModel;
using TechademyEMS.Models.WorkingHoursModel;

namespace TechademyEMS.DatabaseContext
{
    public class EMSDbContext : IdentityDbContext
    {
        public EMSDbContext(DbContextOptions<EMSDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }
        public virtual DbSet<WorkingHours> WorkHours { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }    
        public virtual DbSet<Register> Register { get; set; }   
        public virtual DbSet<PaymentRules> PaymentRules { get; set; }
        //public virtual DbSet<User> Users { get; set; }

    }
}
