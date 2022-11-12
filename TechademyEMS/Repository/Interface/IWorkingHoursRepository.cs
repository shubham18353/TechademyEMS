using TechademyEMS.Models.Working_Hours_Model;
using TechademyEMS.Models.WorkingHoursModel;

namespace TechademyEMS.Repository.Interface
{
    public interface IWorkingHoursRepository
    {
        public List<WorkingHours> GetAll();
        public WorkingHours GetById(int id);
        public WorkingHours Add(AddWorkingHours hours);
        public WorkingHours Update(AddWorkingHours hours, int id);
        bool Delete(int id);
    }
}
