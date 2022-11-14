using TechademyEMS.DatabaseContext;
using TechademyEMS.Models.Working_Hours_Model;
using TechademyEMS.Models.WorkingHoursModel;
using TechademyEMS.Repository.Interface;

namespace TechademyEMS.Repository.Implementation
{
    public class WorkingHoursRepository:IWorkingHoursRepository
    {
        private readonly EMSDbContext _context;

        public WorkingHoursRepository(EMSDbContext context)
        {
            _context = context;
        }

        public WorkingHours Add(AddWorkingHours hours)
        {
            try
            {
                WorkingHours workingHours = new WorkingHours();
                workingHours.EmpId = hours.EmpId;
                workingHours.MonthlyWorkingHours = hours.MonthlyWorkingHours;
                workingHours.EmployeeWorkingHours = hours.EmployeeWorkingHours;

                _context.WorkHours.Add(workingHours);
                _context.SaveChangesAsync();
                return workingHours;
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var hours = _context.WorkHours.FirstOrDefault(x => x.Id == id);
                if (hours != null)
                {
                    _context.WorkHours.Remove(hours);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw new Exception("Working Hours can't be deleted");
            }
        }

        public List<WorkingHours> GetAll()
        {
            try
            {
                List<WorkingHours> hourss = _context.WorkHours.ToList();
                return hourss;
            }
            catch
            {
                throw new Exception("Server Error! Can't load Work Hours");
            }
        }

        public WorkingHours GetById(int id)
        {
            try
            {
                var hours = _context.WorkHours.Find(id);
                if (hours != null)
                    return hours;
                else
                    throw new Exception("Working Hours mismatch! ");
            }
            catch
            {
                throw;
            }
        }

        public WorkingHours Update(AddWorkingHours hours, int id)
        {
            try
            {
                var workingHours = _context.WorkHours.Find(id);
                if (workingHours != null)
                {
                    workingHours.EmpId = hours.EmpId;
                    workingHours.MonthlyWorkingHours = hours.MonthlyWorkingHours;
                    workingHours.EmployeeWorkingHours = hours.EmployeeWorkingHours;

                    
                    _context.SaveChangesAsync();
                    return workingHours;
                }
                else
                    throw new Exception("WorkingHours Not Found!");
            }
            catch
            {
                throw;
            }
        }
    }
}
